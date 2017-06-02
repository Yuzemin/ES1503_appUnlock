using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace UnlockApp
{
    public partial class Form1 : Form
    {
        MachineInfoMode machineInfoMode = new MachineInfoMode();
        private uint PassWord = 0;
        private string FilePath = "";
        byte[] BinData;
        int BinDataLen = 0;

        public Form1()
        {
            InitializeComponent();
            AddLimitNumSel();
        }

        public byte[] CrcCheckOut(byte[] Mat)//Crc校验
        {
            UInt16 crcValue = 0xFFFF;
            byte[] CrcOut = new byte[2];

            for (int i = 0; i < Mat.Count(); i++)
            {
                crcValue ^= Mat[i];
                for (int j = 0; j < 8; j++)
                {
                    if ((crcValue & 0x01) != 0)
                        crcValue = (UInt16)((crcValue >> 1) ^ 0x7a51);
                    else
                        crcValue = (UInt16)(crcValue >> 1);
                }
            }

            CrcOut[0] = (byte)(crcValue & 0xff);
            CrcOut[1] = (byte)(crcValue >> 8);
            return CrcOut;
        }

        private void AddLimitNumSel()
        {
            LimitBox.Items.Add("1w件");

            for (int i = 1; i <= 10; i++)
                LimitBox.Items.Add( (i*10).ToString() +"w件");

            LimitBox.Items.Add("无限制");
            LimitBox.SelectedIndex = 5;
        }

        private void UnLockProcess()
        {
            
            byte[] PW = new byte[4];
            byte[] Result = new byte[4];
            byte[] CrcVal = new byte[2];
            byte LimitVal = 0;

            
            uint Input = Convert.ToUInt32(Mac_ID.Text);

            PassWord = 0;            
            for (int i = 3; i >= 0; i--)
            {
                PW[i] = (byte)(Input & 0xff);
                Input >>= 8;
            }            

            Result[0] = (byte)(0x69 + PW[0] + PW[3]);
            Result[1] = (byte)(0xa3 & PW[1] + PW[2]);
            Result[2] = (byte)(0xde ^ PW[1] + PW[3]);
            Result[3] = (byte)(0xbb - PW[2] + PW[0]);

            CrcVal = CrcCheckOut(Result);

            if (LimitBox.SelectedIndex == 0)
                LimitVal = 1;
            else if (LimitBox.SelectedIndex == 11)
                LimitVal = 0xa6;
            else
                LimitVal = (byte)(LimitBox.SelectedIndex * 10);

            Result[0] ^= CrcVal[0];
            Result[1] ^= CrcVal[1];
            Result[2] ^= LimitVal;

            for (int i = 0; i < 4; i++)
            {
                PassWord <<= 8;
                PassWord += Result[i];
            }

            OW.Text = Convert.ToString(PassWord);
         }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Mac_ID.Text == string.Empty)
            {
                OW.Text = "";
                return;
            }
            UnLockProcess();//获取解密数字   
        }

        private void Mac_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void FileSel_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "*.ECO|*.eco";

            if (Mac_ID.Text == string.Empty)
            {
                MessageBox.Show("机器码不能为空");
                return;
            }
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FilePath = this.openFileDialog1.FileName;

                UnLockProcess();
                FileGetEcoVal(FilePath);
                CreatNewEcoFile();
                MessageBox.Show("升级文件已生成");
            }
        }


        //读ECO文件 分别获得 总长度 ，备注信息的长度 和 BIN文件内容的长度
        private void FileGetEcoVal(String SourcePath)
        {
            int length;            
            byte[] infoDatas;            

            FileInfo fileInfo = new FileInfo(SourcePath);
            machineInfoMode.FileLen = (int)fileInfo.Length;
            
            BinaryReader binaryReader = new BinaryReader(new FileStream(SourcePath, FileMode.Open));           
            
            for (int i = 0; i < 3; i++)//信息就三个模块：时间、版本、附加信息
            {
                length = ReadNegateData(binaryReader.ReadByte());//读内容长度 
                infoDatas = binaryReader.ReadBytes(length); //读取相应长度的字节数
                infoDatas = ReadNegateData(infoDatas);
                switch (i)
                {
                    case 0:                        
                        machineInfoMode.DateTime = Encoding.Default.GetString(infoDatas);
                        machineInfoMode.DataLen = length;
                        break;
                    case 1:
                        machineInfoMode.Version = Encoding.Default.GetString(infoDatas);
                        machineInfoMode.VersionLen = length;
                        break;
                    case 2:
                        machineInfoMode.AddInfo = Encoding.UTF8.GetString(infoDatas);
                        machineInfoMode.AddInfoLen = length;
                        break;
                    default:
                        break;
                }
            }
            int MsgLen = machineInfoMode.DataLen + machineInfoMode.VersionLen + machineInfoMode.AddInfoLen + 3;
            BinDataLen = machineInfoMode.FileLen - MsgLen;
            BinData = new byte[BinDataLen];
            binaryReader.Read(BinData, 0, BinDataLen);
            binaryReader.Close();
        }

        private byte ReadNegateData(byte readDatas)
        {
            return readDatas ^= 0xff;
        }

        private byte[] ReadNegateData(byte[] readDatas)
        {
            for (int i = 0; i < readDatas.Length; i++)
                readDatas[i] ^= 0xff;
            return readDatas;
        }

        private void WriteNegateData(byte[] writeDatas, BinaryWriter binaryWriter)//写入取反数据
        {
            for (int i = 0; i < writeDatas.Length; i++)
                WriteNegateData(writeDatas[i], binaryWriter);
        }
        private void WriteNegateData(byte writeData, BinaryWriter binaryWriter)
        {
            writeData ^= 0xFF;
            binaryWriter.Write(writeData);
        }

        //写入加密内容 的长度和 内容 bin文件内容
        private void CreatNewEcoFile()
        {
            string DestPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            string day = DateTime.Now.ToString("yyMMdd");
            DestPath += "EcoUpdate" + day + ".ECO";
            BinaryWriter binaryWriter = new BinaryWriter(new FileStream(DestPath, FileMode.OpenOrCreate));

            WriteNegateData((byte)machineInfoMode.DataLen, binaryWriter);
            WriteNegateData(Encoding.Default.GetBytes(machineInfoMode.DateTime),binaryWriter);

            WriteNegateData((byte)machineInfoMode.VersionLen, binaryWriter);
            WriteNegateData(Encoding.Default.GetBytes(machineInfoMode.Version),binaryWriter);
            
            String PW = PassWord.ToString();
            WriteNegateData((byte)PW.Length, binaryWriter);
            WriteNegateData(Encoding.UTF8.GetBytes(PW), binaryWriter);

            binaryWriter.Write(BinData, 0, BinDataLen);
            binaryWriter.Close();
        }

        private void Mac_ID_TextChanged(object sender, EventArgs e)
        {
            if (Mac_ID.Text != string.Empty)
            {
                if (long.Parse(Mac_ID.Text) > int.MaxValue)
                    Mac_ID.Text = int.MaxValue.ToString();
            }
        }
    }
}
