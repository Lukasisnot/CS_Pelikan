using System.ComponentModel;

namespace simpleDuolingo.Views;

partial class Languages
{
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        button1 = new System.Windows.Forms.Button();
        button2 = new System.Windows.Forms.Button();
        button3 = new System.Windows.Forms.Button();
        textBox1 = new System.Windows.Forms.TextBox();
        textBox2 = new System.Windows.Forms.TextBox();
        button4 = new System.Windows.Forms.Button();
        textBox3 = new System.Windows.Forms.TextBox();
        listView1 = new System.Windows.Forms.ListView();
        listView2 = new System.Windows.Forms.ListView();
        idCol = new System.Windows.Forms.ColumnHeader();
        nameCol = new System.Windows.Forms.ColumnHeader();
        createdatCol = new System.Windows.Forms.ColumnHeader();
        modifiedatCol = new System.Windows.Forms.ColumnHeader();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(25, 28);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(75, 23);
        button1.TabIndex = 0;
        button1.Text = "Back";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // button2
        // 
        button2.Location = new System.Drawing.Point(141, 89);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(102, 23);
        button2.TabIndex = 1;
        button2.Text = "Create";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // button3
        // 
        button3.Location = new System.Drawing.Point(141, 150);
        button3.Name = "button3";
        button3.Size = new System.Drawing.Size(102, 23);
        button3.TabIndex = 2;
        button3.Text = "Delete by ID";
        button3.UseVisualStyleBackColor = true;
        button3.Click += button3_Click;
        // 
        // textBox1
        // 
        textBox1.Location = new System.Drawing.Point(141, 60);
        textBox1.Name = "textBox1";
        textBox1.Size = new System.Drawing.Size(148, 23);
        textBox1.TabIndex = 3;
        textBox1.KeyDown += textBox1_KeyDown;
        // 
        // textBox2
        // 
        textBox2.Location = new System.Drawing.Point(141, 121);
        textBox2.Name = "textBox2";
        textBox2.Size = new System.Drawing.Size(148, 23);
        textBox2.TabIndex = 4;
        textBox2.KeyDown += textBox2_KeyDown;
        // 
        // button4
        // 
        button4.Location = new System.Drawing.Point(141, 179);
        button4.Name = "button4";
        button4.Size = new System.Drawing.Size(102, 23);
        button4.TabIndex = 5;
        button4.Text = "Refresh";
        button4.UseVisualStyleBackColor = true;
        button4.Click += button4_Click;
        // 
        // textBox3
        // 
        textBox3.Location = new System.Drawing.Point(25, 316);
        textBox3.Name = "textBox3";
        textBox3.ReadOnly = true;
        textBox3.Size = new System.Drawing.Size(264, 23);
        textBox3.TabIndex = 7;
        // 
        // listView1
        // 
        listView1.Location = new System.Drawing.Point(295, 60);
        listView1.Name = "listView1";
        listView1.Size = new System.Drawing.Size(294, 279);
        listView1.TabIndex = 6;
        listView1.UseCompatibleStateImageBehavior = false;
        listView1.View = System.Windows.Forms.View.Details;
        // 
        // listView2
        // 
        listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { idCol, nameCol, createdatCol, modifiedatCol });
        listView2.Location = new System.Drawing.Point(295, 60);
        listView2.Name = "listView2";
        listView2.Size = new System.Drawing.Size(479, 331);
        listView2.TabIndex = 8;
        listView2.UseCompatibleStateImageBehavior = false;
        listView2.View = System.Windows.Forms.View.Details;
        // 
        // idCol
        // 
        idCol.Name = "idCol";
        idCol.Text = "ID";
        // 
        // nameCol
        // 
        nameCol.Name = "nameCol";
        nameCol.Text = "Name";
        nameCol.Width = 105;
        // 
        // createdatCol
        // 
        createdatCol.Name = "createdatCol";
        createdatCol.Text = "Created At";
        createdatCol.Width = 128;
        // 
        // modifiedatCol
        // 
        modifiedatCol.Name = "modifiedatCol";
        modifiedatCol.Text = "Modified At";
        modifiedatCol.Width = 136;
        // 
        // Languages
        // 
        Controls.Add(listView2);
        Controls.Add(textBox3);
        Controls.Add(button4);
        Controls.Add(textBox2);
        Controls.Add(textBox1);
        Controls.Add(button3);
        Controls.Add(button2);
        Controls.Add(button1);
        Size = new System.Drawing.Size(754, 511);
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.ColumnHeader modifiedatCol;

    private System.Windows.Forms.ColumnHeader createdatCol;

    private System.Windows.Forms.ColumnHeader nameCol;

    private System.Windows.Forms.ColumnHeader idCol;

    private System.Windows.Forms.ListView listView2;

    private System.Windows.Forms.TextBox textBox3;

    private System.Windows.Forms.ListView listView1;

    private System.Windows.Forms.Button button4;

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.TextBox textBox2;

    #endregion
}