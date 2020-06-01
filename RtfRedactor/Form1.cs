using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RtfRedactor
{
    public partial class MainForm : Form
    {
        string filePath = "";
        bool needsSaving = false;
        bool ehereWasConservation = false;
        int characters = 0;
        public MainForm()
        {
            InitializeComponent();
            saveFileDialog1.FileOk += (s,e)=>  Save(saveFileDialog1.FileName);
            selectAllToolStripMenuItem.Click += (s, e) => richTextBox1.SelectAll();
            
        }

        

        private void Save(string fileName)
        {
            if(Path.GetExtension(filePath)== ".rtf")
            {
                richTextBox1.SaveFile(fileName);
                filePath = fileName;
                needsSaving = false;
                ehereWasConservation = true;
            }
            else
            {
                MessageBox.Show("this not rtf type");
            }
            
        }

        

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
                 openFileDialog1.FileName.Length > 0)
            {
                filePath = openFileDialog1.FileName;
                richTextBox1.Clear();
                if(Path.GetExtension(filePath) == ".rtf")
                {

                    richTextBox1.LoadFile(openFileDialog1.FileName);
                    this.Text = openFileDialog1.FileName;
                    richTextBox1.Enabled = true;
                    needsSaving = false;
                    ehereWasConservation = false;
                    characters = richTextBox1.Text.Length;

                }
                else
                {
                    MessageBox.Show("this not rtf type");
                }
                
            }
            
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

     
        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(richTextBox1.CanUndo)
                richTextBox1.Undo();
        }

        private void RedoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(richTextBox1.CanRedo)
                richTextBox1.Redo();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fontDialog1.Font;
            }
        }

        private void ColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = colorDialog1.Color;
            }
        }

        private void LeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void RightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void CenterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void CheckMenuFontCharacterStyle()
        {
            if (richTextBox1.SelectionFont.Bold == true)
                BoldToolStripMenuItem.Checked = true;
            else BoldToolStripMenuItem.Checked = false;

            if (richTextBox1.SelectionFont.Italic == true)
                ItalicToolStripMenuItem.Checked = true;
            else ItalicToolStripMenuItem.Checked = false;

            if (richTextBox1.SelectionFont.Underline == true)
                UnderLineToolStripMenuItem.Checked = true;
            else UnderLineToolStripMenuItem.Checked = false;

            if (richTextBox1.SelectionFont.Strikeout == true)
                StrikeoutToolStripMenuItem.Checked = true;
            else StrikeoutToolStripMenuItem.Checked = false;

        }

        private void BoldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(richTextBox1.SelectionFont != null)
            {
                System.Drawing.Font currentFont = richTextBox1.SelectionFont;
                System.Drawing.FontStyle newFontStyle;

                if (richTextBox1.SelectionFont.Bold == true)
                    newFontStyle = FontStyle.Regular;
                else
                    newFontStyle = FontStyle.Bold;

                richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);

                CheckMenuFontCharacterStyle();
            }
        }

        private void ItalicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(richTextBox1.SelectionFont != null)
            {
                System.Drawing.Font currentFont = richTextBox1.SelectionFont;
                System.Drawing.FontStyle newFontStyle;
                CheckMenuFontCharacterStyle();

                if (richTextBox1.SelectionFont.Italic == true)
                    newFontStyle = FontStyle.Regular;
                else
                    newFontStyle = FontStyle.Italic;

                richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
                CheckMenuFontCharacterStyle();


            }
        }

        private void StrikeoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                System.Drawing.Font currentFont = richTextBox1.SelectionFont;
                System.Drawing.FontStyle newFontStyle;
                

                if (richTextBox1.SelectionFont.Italic == true)
                    newFontStyle = FontStyle.Regular;
                else
                    newFontStyle = FontStyle.Strikeout;

                richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
                CheckMenuFontCharacterStyle();


            }

        }

        private void UnderLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                System.Drawing.Font currentFont = richTextBox1.SelectionFont;
                System.Drawing.FontStyle newFontStyle;
                

                if (richTextBox1.SelectionFont.Italic == true)
                    newFontStyle = FontStyle.Regular;
                else
                    newFontStyle = FontStyle.Underline;

                richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
                CheckMenuFontCharacterStyle();


            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            if (needsSaving)
            {
                saveFileDialog1.FileName = filePath;
                saveFileDialog1.ShowDialog();
            }
            else
            {
                Save(filePath);
            }
        }

        

        private void NewToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            

            var newFileDialog = new NewFileForm();
            if(newFileDialog.ShowDialog()== DialogResult.OK)
            {
                filePath = newFileDialog.fileName;
                richTextBox1.Clear();
                richTextBox1.Enabled = true;
                needsSaving = true;
                ehereWasConservation = false;
                characters = richTextBox1.Text.Length;
            }
 
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var pDoc = new PrintDocument();
            pDoc.DocumentName = filePath;
            pDoc.PrintPage += PrinterHandler;
            printDialog1.Document = pDoc;
            if(printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDialog1.Document.Print();
            }
        }

        private void PrinterHandler(object sendler, PrintPageEventArgs e)
        {
            int count = 0;
            Font printFont = fontDialog1.Font;
            Brush printBrush = new SolidBrush(colorDialog1.Color);

            foreach(var line in richTextBox1.Lines)
            {
                float yPos = e.MarginBounds.Top + (count * printFont.GetHeight(e.Graphics));
                e.Graphics.DrawString(line, printFont, printBrush,
                                        e.MarginBounds.Left, yPos, new StringFormat());

                count++;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ehereWasConservation == false & (characters < richTextBox1.Text.Length || richTextBox1.Text.Length < characters))
            {
                DialogResult res = MessageBox.Show("Сохранить изменения?", "Файл был изменен", MessageBoxButtons.YesNoCancel);
                if (res == DialogResult.Yes)
                {
                    Save(filePath);
                    
                }
                else if (res == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }

            }
            
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void enlargeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(richTextBox1.Text, 34, richTextBox1.Font.Style);
            
        }

        
    }
}
