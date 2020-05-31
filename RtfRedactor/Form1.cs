using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RtfRedactor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

       

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
                 openFileDialog1.FileName.Length > 0)
            {
                try
                {
                    MessageBox.Show(openFileDialog1.FileName.EndsWith(".rtf").ToString());
                    if (openFileDialog1.FileName.EndsWith(".rtf"))
                    {
                        richTextBox1.LoadFile(openFileDialog1.FileName);
                        this.Text = openFileDialog1.FileName;
                    }
                    else
                    {
                        MessageBox.Show("this not rtf file");
                    }
                }
                catch(IOException)
                {
                    MessageBox.Show("111");
                }
                catch(ArgumentException)
                {
                    MessageBox.Show("22");
                }
                
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
      saveFileDialog1.FileName.Length > 0)
            {
                // Save the contents of the RichTextBox into the file.
                richTextBox1.SaveFile(saveFileDialog1.FileName);
                this.Text = saveFileDialog1.FileName;
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Modified && this.Text.EndsWith(".rtf"))
            {
                DialogResult res = MessageBox.Show("Сохранить изменения?", "Файл был изменен", MessageBoxButtons.YesNoCancel);
                if (res == DialogResult.Yes)
                {
                    SaveToolStripMenuItem_Click(this,e);
                    Application.Exit();
                }
                else if(res == DialogResult.No)
                {
                    Application.Exit();
                }
                else if(res == DialogResult.Cancel)
                {
                    
                }
                
            }
            else
            {
                Application.Exit();
            }


            

        }

        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void RedoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
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
            if (richTextBox1.Modified && this.Text.EndsWith(".rtf"))
            {
                MessageBox.Show(this.Text);
                richTextBox1.SaveFile(this.Text);
            }
 
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (richTextBox1.Modified && this.Text.EndsWith(".rtf"))
                {
                    DialogResult res = MessageBox.Show("Сохранить изменения?", "Файл был изменен", MessageBoxButtons.YesNoCancel);
                    if (res == DialogResult.Yes)
                    {
                        SaveToolStripMenuItem_Click(this, e);
                        Application.Exit();
                    }
                    else if (res == DialogResult.No)
                    {
                        Application.Exit();
                    }
                    else if (res == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                    }

                }
                else
                {
                    Application.Exit();
                }
            }

        }

        private void NewToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            this.Text = "Form1";
 
        }
    }
}
