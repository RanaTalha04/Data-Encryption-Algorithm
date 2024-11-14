using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Windows.Forms;

namespace DES_Algo
{
    public partial class DES : Form
    {
        public DES()
        {
            InitializeComponent();

        }

        public static string? MasterKey;
        public static string? PlainText;

        private void readfile_bttn_Click(object sender, EventArgs e)
        {
            string filepath;
            string pdfText;

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "PDF Files (*.pdf)|*.pdf",
                Title = "Select a PDF File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filepath = openFileDialog.FileName;
                pdfText = ReadPdf(filepath);
                PlainText = pdfText;
                filePath_tb.Text = filepath;
            }

        }
        private string ReadPdf(string filePath)
        {
            try
            {
                using (PdfReader reader = new PdfReader(filePath))
                {
                    string text = "";
                    for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                        text += PdfTextExtractor.GetTextFromPage(reader, i);
                    }
                    return text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading PDF: " + ex.Message);
                return "";
            }
        }

        public static int[] InitialPermutation = {58, 50, 42, 34, 26, 18, 10, 2,
                                           60, 52, 44, 36, 28, 20, 12, 4,
                                           62, 54, 46, 38, 30, 22, 14, 6,
                                           64, 56, 48, 40, 32, 24, 16, 8,
                                           57, 49, 41, 33, 25, 17,  9, 1,
                                           59, 51, 43, 35, 27, 19, 11, 3,
                                           61, 53, 45, 37, 29, 21, 13, 5,
                                           63, 55, 47, 39, 31, 23, 15, 7 };

        public static int[] FinalPermutation = {40, 8, 48, 16, 56, 24, 64, 32,
                                         39, 7, 47, 15, 55, 23, 63, 31,
                                         38, 6, 46, 14, 54, 22, 62, 30,
                                         37, 5, 45, 13, 53, 21, 61, 29,
                                         36, 4, 44, 12, 52, 20, 60, 28,
                                         35, 3, 43, 11, 51, 19, 59, 27,
                                         34, 2, 42, 10, 50, 18, 58, 26,
                                         33, 1, 41, 9, 49, 17, 57, 25 };

        public static int[] ExpansionPermuatation = {32,  1,  2,  3,  4, 5,
                                               4,  5,  6,  7,  8, 9,
                                               8,  9, 10, 11, 12, 13,
                                              12, 13, 14, 15, 16, 17,
                                              16, 17, 18, 19, 20, 21,
                                              20, 21, 22, 23, 24, 25,
                                              24, 25, 26, 27, 28, 29,
                                              28, 29, 30, 31, 32, 1 };

        public static int[] permutationFunction = {16,  7, 20, 21, 29, 12, 28, 17,
                                             1, 15, 23, 26,  5, 18, 31, 10,
                                             2,  8, 24, 14, 32, 27,  3,  9,
                                            19, 13, 30,  6, 22, 11,  4, 25 };

        public static int[,,] SBox = new int[,,]
{
    {
        {14, 4, 13, 1, 2, 15, 11, 8, 3, 10, 6, 12, 5, 9, 0, 7},
        {0, 15, 7, 4, 14, 2, 13, 1, 10, 6, 12, 11, 9, 5, 3, 8},
        {4, 1, 14, 8, 13, 6, 2, 11, 15, 12, 9, 7, 3, 10, 5, 0},
        {15, 12, 8, 2, 4, 9, 1, 7, 5, 11, 3, 14, 10, 0, 6, 13}
    },
    {
        {15, 1, 8, 14, 6, 11, 3, 4, 9, 7, 2, 13, 12, 0, 5, 10},
        {3, 13, 4, 7, 15, 2, 8, 14, 12, 0, 1, 10, 6, 9, 11, 5},
        {0, 14, 7, 11, 10, 4, 13, 1, 5, 8, 12, 6, 9, 3, 2, 15},
        {13, 8, 10, 1, 3, 15, 4, 2, 11, 6, 7, 12, 0, 5, 14, 9}
    },
    {
        {10, 0, 9, 14, 6, 3, 15, 5, 1, 13, 12, 7, 11, 4, 2, 8},
        {13, 7, 0, 9, 3, 4, 6, 10, 2, 8, 5, 14, 12, 11, 15, 1},
        {13, 6, 4, 9, 8, 15, 3, 0, 11, 1, 2, 12, 5, 10, 14, 7},
        {1, 10, 13, 0, 6, 9, 8, 7, 4, 15, 14, 3, 11, 5, 2, 12}
    },
    {
        {7, 13, 14, 3, 0, 6, 9, 10, 1, 2, 8, 5, 11, 12, 4, 15},
        {13, 8, 11, 5, 6, 15, 0, 3, 4, 7, 2, 12, 1, 10, 14, 9},
        {10, 6, 9, 0, 12, 11, 7, 13, 15, 1, 3, 14, 5, 2, 8, 4},
        {3, 15, 0, 6, 10, 1, 13, 8, 9, 4, 5, 11, 12, 7, 2, 14}
    },
    {
        {2, 12, 4, 1, 7, 10, 11, 6, 8, 5, 3, 15, 13, 0, 14, 9},
        {14, 11, 2, 12, 4, 7, 13, 1, 5, 0, 15, 10, 3, 9, 8, 6},
        {4, 2, 1, 11, 10, 13, 7, 8, 15, 9, 12, 5, 6, 3, 0, 14},
        {11, 8, 12, 7, 1, 14, 2, 13, 6, 15, 0, 9, 10, 4, 5, 3}
    },
    {
        {12, 1, 10, 15, 9, 2, 6, 8, 0, 13, 3, 4, 14, 7, 5, 11},
        {10, 15, 4, 2, 7, 12, 9, 5, 6, 1, 13, 14, 0, 11, 3, 8},
        {9, 14, 15, 5, 2, 8, 12, 3, 7, 0, 4, 10, 1, 13, 11, 6},
        {4, 3, 2, 12, 9, 5, 15, 10, 11, 14, 1, 7, 6, 0, 8, 13}
    },
    {
        {4, 11, 2, 14, 15, 0, 8, 13, 3, 12, 9, 7, 5, 10, 6, 1},
        {13, 0, 11, 7, 4, 9, 1, 10, 14, 3, 5, 12, 2, 15, 8, 6},
        {1, 4, 11, 13, 12, 3, 7, 14, 10, 15, 6, 8, 0, 5, 9, 2},
        {6, 11, 13, 8, 1, 4, 10, 7, 9, 5, 0, 15, 14, 2, 3, 12}
    },
    {
        {13, 2, 8, 4, 6, 15, 11, 1, 10, 9, 3, 14, 5, 0, 12, 7},
        {1, 15, 13, 8, 10, 3, 7, 4, 12, 5, 6, 11, 0, 14, 9, 2},
        {7, 11, 4, 1, 9, 12, 14, 2, 0, 6, 10, 13, 15, 3, 5, 8},
        {2, 1, 14, 7, 4, 10, 8, 13, 15, 12, 9, 0, 3, 5, 6, 11}
    }
};

        public static int[] PC1 = {57, 49, 41, 33, 25, 17,  9,
                             1, 58, 50, 42, 34, 26, 18,
                            10,  2, 59, 51, 43, 35, 27,
                            19, 11,  3, 60, 52, 44, 36,
                            63, 55, 47, 39, 31, 23, 15,
                             7, 62, 54, 46, 38, 30, 22,
                            14,  6, 61, 53, 45, 37, 29,
                            21, 13,  5, 28, 20, 12,  4};

        public static int[] PC2 = {14, 17, 11, 24,  1,  5,  3, 28,
                            15,  6, 21, 10, 23, 19, 12,  4,
                            26,  8, 16,  7, 27, 20, 13,  2,
                            41, 52, 31, 37, 47, 55, 30, 40,
                            51, 45, 33, 48, 44, 49, 39, 56,
                            34, 53, 46, 42, 50, 36, 29, 32 };

        public static int[] bitsRotated = { 1, 1, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1 };

        static Dictionary<char, int> charToAsciiDict = new Dictionary<char, int>
        {
            {'A', 65}, {'B', 66}, {'C', 67}, {'D', 68}, {'E', 69}, {'F', 70},
            {'G', 71}, {'H', 72}, {'I', 73}, {'J', 74}, {'K', 75}, {'L', 76},
            {'M', 77}, {'N', 78}, {'O', 79}, {'P', 80}, {'Q', 81}, {'R', 82},
            {'S', 83}, {'T', 84}, {'U', 85}, {'V', 86}, {'W', 87}, {'X', 88},
            {'Y', 89}, {'Z', 90},

            {'a', 97}, {'b', 98}, {'c', 99}, {'d', 100}, {'e', 101}, {'f', 102},
            {'g', 103}, {'h', 104}, {'i', 105}, {'j', 106}, {'k', 107}, {'l', 108},
            {'m', 109}, {'n', 110}, {'o', 111}, {'p', 112}, {'q', 113}, {'r', 114},
            {'s', 115}, {'t', 116}, {'u', 117}, {'v', 118}, {'w', 119}, {'x', 120},
            {'y', 121}, {'z', 122},

            {'0', 48}, {'1', 49}, {'2', 50}, {'3', 51}, {'4', 52}, {'5', 53},
            {'6', 54}, {'7', 55}, {'8', 56}, {'9', 57},

            {' ', 32},
            {',', 44},
            {'.', 46},
            {'\'', 39}
        };

        public static string HexToBinary(string hex)
        {
            string binary = "";

            foreach (char c in hex.ToUpper())
            {
                if ("0123456789ABCDEF".Contains(c))
                {
                    switch (c)
                    {
                        case '0': binary += "00000000"; break;
                        case '1': binary += "00000001"; break;
                        case '2': binary += "00000010"; break;
                        case '3': binary += "00000011"; break;
                        case '4': binary += "00000100"; break;
                        case '5': binary += "00000101"; break;
                        case '6': binary += "00000110"; break;
                        case '7': binary += "00000111"; break;
                        case '8': binary += "00001000"; break;
                        case '9': binary += "00001001"; break;
                        case 'A': binary += "00001010"; break;
                        case 'B': binary += "00001011"; break;
                        case 'C': binary += "00001100"; break;
                        case 'D': binary += "00001101"; break;
                        case 'E': binary += "00001110"; break;
                        case 'F': binary += "00001111"; break;
                    }
                }
                else
                {
                    if (charToAsciiDict.ContainsKey(c))
                    {

                        int asciiValue = charToAsciiDict[c];
                        string binaryValue = Convert.ToString(asciiValue, 2).PadLeft(8, '0');
                        binary += binaryValue;
                    }
                    else
                    {
                        binary += "";
                    }
                }
            }

            return binary;
        }

        public static string BinaryToHex(string binary)
        {
            while (binary.Length % 4 != 0)
            {
                binary = "0" + binary;
            }

            string hex = "";
            for (int i = 0; i < binary.Length; i += 4)
            {
                string fourBits = binary.Substring(i, 4);

                if (fourBits == "0000")
                { hex += "0"; }
                else if (fourBits == "0001")
                { hex += "1"; }
                else if (fourBits == "0010")
                { hex += "2"; }
                else if (fourBits == "0011")
                { hex += "3"; }
                else if (fourBits == "0100")
                { hex += "4"; }
                else if (fourBits == "0101")
                { hex += "5"; }
                else if (fourBits == "0110")
                { hex += "6"; }
                else if (fourBits == "0111")
                { hex += "7"; }
                else if (fourBits == "1000")
                { hex += "8"; }
                else if (fourBits == "1001")
                { hex += "9"; }
                else if (fourBits == "1010")
                { hex += "A"; }
                else if (fourBits == "1011")
                { hex += "B"; }
                else if (fourBits == "1100")
                { hex += "C"; }
                else if (fourBits == "1101")
                { hex += "D"; }
                else if (fourBits == "1110")
                { hex += "E"; }
                else if (fourBits == "1111")
                { hex += "F"; }
            }
            return hex;
        }

        public static string textToBinary(string txt)
        {
            string BinaryText = HexToBinary(txt);
            return BinaryText;
        }

        public static string Permute(string binaryText, int[] permutationTable, int blockSize)
        {
            char[] permutedBlock = new char[blockSize];  

            for (int i = 0; i < blockSize; i++)
            {
                int newIndex = permutationTable[i] - 1; 
                permutedBlock[i] = binaryText[newIndex];
            }

            return new string(permutedBlock);
        }

        public static string ConvertToBlocks(string PT)
        {
            string blocks = "";
            string binaryPT = textToBinary(PT);

            for (int i = 0; i < binaryPT.Length; i += 64)
            {
                string block;

                if (i + 64 <= binaryPT.Length)
                {
                    block = binaryPT.Substring(i, 64);
                }

                else
                {
                    block = binaryPT.Substring(i).PadRight(64, '0');
                }
                blocks = blocks + block;
            } 
            return blocks;

        }

        public static string XOR(string a, string b)
        {
            string result = "";
            for(int i = 0; i < a.Length; i++)
            {
                if (a[i] == b[i])
                {
                    result += "0";
                }
                else
                {
                    result += "1";
                }
            }
            return result;
        }
        public static string Encrypt(string PT)
        {
            string binaryTextBlocks = ConvertToBlocks(PT);
            string permutedText = "";
            string currentBlock = "";
            string permutedBlock = "";
            string left_half = "";
            string right_half = "";

            for (int i = 0; i < binaryTextBlocks.Length; i += 64)
            {

                if (i + 64 <= binaryTextBlocks.Length)
                {
                    currentBlock = binaryTextBlocks.Substring(i, 64);
                    permutedBlock = Permute(currentBlock, InitialPermutation, 64);
                }
                else
                {
                    currentBlock = binaryTextBlocks.Substring(i);
                    string paddedBlock = currentBlock.PadRight(64, '0');

                    permutedBlock = Permute(paddedBlock, InitialPermutation, 64);

                }
                permutedText = permutedText + permutedBlock;

                left_half = permutedBlock.Substring(0, 32);
                right_half = permutedBlock.Substring(32, 32);
            }

            for(int i = 0; i < 16; i++)
            {
                string right_Expand = Permute(right_half, ExpansionPermuatation, 48);
                //xor_RK = XOR(right_Expand, )
            }

            return permutedText;
            //return binaryTextBlocks;
        }

        public static string Key_handling(string masterKey)
        {
            string binaryKey = textToBinary(masterKey);
            string key = Permute(binaryKey, PC1, 56);
            string left_half = key.Substring(0, 28);
            string right_half = key.Substring(28, 56);
            return binaryKey;
        }
        private void Start_Bttn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filePath_tb.Text) || string.IsNullOrEmpty(masterKey_tb.Text) || masterKey_tb.Text.Length != 8)
            {
                MessageBox.Show("Please select file path or input key of length 8.");
            }
            else if(Encryption_CB.Checked == Decryption_CB.Checked)
            {
                MessageBox.Show("Select either encryption or decryption not both.");
            }
            else
            {
                completeness_bar.Value = 0;
                MasterKey = masterKey_tb.Text;
                Status_lbl.Visible = true;

                for (int i = 0; i <= 100; i += 10)
                {
                    System.Threading.Thread.Sleep(100); 
                    completeness_bar.Value = i;
                }

                Status_lbl.Visible = true;
                Success_lbl.Visible = true;
                Success_lbl.Text = "Operation Successfull";
                Success_lbl.BackColor = System.Drawing.Color.Green;

                richTextBox1.Text = Encrypt(PlainText);
                //richTextBox1.Text = ConvertToBlocks(MasterKey);
            }
        }
    }
}
