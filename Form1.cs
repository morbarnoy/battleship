using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {         
        #region all the global stuff 
        Button[,] board;
        int done = 0, ugh1 = 0, click = 0, done1 = 0, p = 0, piece = 0, time = 0, turn = 0, worked = 0, dir=0, sink = 0, start, ships, number = 0, yes = 0, i, j, lasti = 0, lastj = 0, hit = 0, hit1 = 0, set = 0, movementi = 1, movementj = 0, ugh = 0, guesshuman = 0;
        int[,] board5, board1, board2, board3, board4, board10, sinkingshipsme, sinkingshipsenemy;
        int[] sank, sank1;
        Button[,] boarde,boardb,boardc, boardd;          
        Random ran = new Random();     
        #endregion
        #region 1v1
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" welcom to battle ship, first you hav eto set up your board the first ship you put is your biggest you can not place ships on the sides of your ships ( the blue ) later hand the computer to your friend so they can do the same and then start guessing " );
            label1.Visible = false;
            label2.Visible = false;
            start = 0;          
            string s = textBox1.Text; //what is in the text box                        //MessageBox.Show(s); // show s
            number = int.Parse(s);
            string t = textBox2.Text; //what is in the text box                        //MessageBox.Show(s); // show s
            ships = int.Parse(t);
            board = new Button[number, number];
            sinkingshipsme = new int[number, number];
            sinkingshipsenemy = new int[number, number];
            board1 = new int[number, number];
            board10 = new int[number, number];
            boardb = new Button[number, number];
            board2 = new int[number, number];
            boardc = new Button[number, number];
            // board3 = new int[number, number];
            boardd = new Button[number, number];
            board4 = new int[number, number];
            button1.Visible = false;
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
            button2.Visible = false;           
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            sank = new int[5];
            sank1 = new int[5];
            this.Height = panel1.Height + 700;
            this.Width = panel1.Width + 800;
            int r, c;
            r = 0;
            int num = 0;
            panel1.Width = number * 40; // makes it squares 
            panel1.Height = number * 40;
            while (r < board.GetLength(0))
            {
                c = 0;
                while (c < board.GetLength(1))
                {
                    board[r, c] = new Button();
                    board1[r, c] = 0;
                    board[r, c].Size = new Size(panel1.Width / number, panel1.Height / number);
                    board[r, c].Location = new Point(c * panel1.Width / number, r * panel1.Height / number);
                    board[r, c].Tag = num;// new thing to be abe to press the button 
                    num++;
                    board[r, c].Click += Form1_Click1;
                    board[r, c].FlatStyle = FlatStyle.Flat;
                    board[r, c].FlatAppearance.BorderSize = 1;
                    panel1.Controls.Add(board[r, c]);
                    c++;
                }
                r++;
            }
            boardb = new Button[number, number];
            board2 = new int[number, number];
            //button1.Visible = false;
            r = 0;
            num = 0;
            panel2.Width = number * 40; // makes it squares 
            panel2.Height = number * 40;
            while (r < boardb.GetLength(0))
            {
                c = 0;
                while (c < boardb.GetLength(1))
                {
                    boardb[r, c] = new Button();
                    boardb[r, c].BackColor = Color.Yellow;
                    board2[r, c] = 10;
                    boardb[r, c].Size = new Size(panel2.Width / number, panel2.Height / number);
                    boardb[r, c].Location = new Point(c * panel2.Width / number, r * panel2.Height / number);
                    boardb[r, c].Tag = num;// new thing to be abe to press the button 
                    num++;
                    boardb[r, c].Click += Form1_Click2;
                    boardb[r, c].FlatStyle = FlatStyle.Flat;
                    boardb[r, c].FlatAppearance.BorderSize = 1;
                    panel2.Controls.Add(boardb[r, c]);
                    c++;
                }
                r++;
            }
            boardc = new Button[number, number];
            board3 = new int[number, number];
            //button1.Visible = false;
            r = 0;
            num = 0;
            panel3.Width = number * 40; // makes it squares 
            panel3.Height = number * 40;
            while (r < boardc.GetLength(0))
            {
                c = 0;
                while (c < boardc.GetLength(1))
                {
                    boardc[r, c] = new Button();
                    board3[r, c] = 0;
                    boardc[r, c].Size = new Size(panel3.Width / number, panel3.Height / number);
                    boardc[r, c].Location = new Point(c * panel3.Width / number, r * panel3.Height / number);
                    boardc[r, c].Tag = num;// new thing to be abe to press the button 
                    num++;
                    boardc[r, c].Click += Form1_Click;
                    boardc[r, c].FlatStyle = FlatStyle.Flat;
                    boardc[r, c].FlatAppearance.BorderSize = 1;
                    panel3.Controls.Add(boardc[r, c]);
                    c++;
                }
                r++;
            }
            boardd = new Button[number, number];
            board4 = new int[number, number];
            //button1.Visible = false;
            r = 0;
            panel4.Width = number * 40; // makes it squares 
            panel4.Height = number * 40;
            num = 0;
            while (r < boardd.GetLength(0))
            {
                c = 0;
                while (c < boardd.GetLength(1))
                {
                    boardd[r, c] = new Button();
                    boardd[r, c].BackColor = Color.Green;
                    board4[r, c] = 10;
                    boardd[r, c].Size = new Size(panel4.Width / number, panel4.Height / number);
                    boardd[r, c].Location = new Point(c * panel4.Width / number, r * panel4.Height / number);
                    boardd[r, c].Tag = num;// new thing to be abe to press the button 
                    num++;
                    boardd[r, c].Click += Form1_Click3;
                    boardd[r, c].FlatStyle = FlatStyle.Flat;
                    boardd[r, c].FlatAppearance.BorderSize = 1;
                    panel4.Controls.Add(boardd[r, c]);
                    c++;
                }
                r++;
            }
            updateScreen(board1, board);
            updateScreen(board2, boardb);
            updateScreen(board3, boardc);
            updateScreen(board4, boardd);
        }// 1v1 board builder 
        void updateScreen(int[,] b, Button [,] c)
        {
                          
            for (int i = 0; i < b.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    if (b[i, j] == 1 || b[i, j] == 100)
                    {
                        c[i, j].BackColor = Color.Black;
                    }
                    else if (b[i, j] == 2)
                    {
                        c[i, j].BackColor = Color.Red;
                    }
                    else if (b[i, j] == 5)
                    {
                        c[i, j].BackColor = Color.Purple;
                    }
                    else if (b[i, j] == 10)
                    {
                        c[i, j].BackColor = Color.Yellow;
                    }
                    else if (b[i, j] == 0)
                    {
                        c[i, j].BackColor = Color.White;
                    }
                    else if (b[i, j] == 20)
                    {
                        c[i, j].BackColor = Color.Blue;
                    }
                    else if (b[i, j] == 15)
                    {
                        c[i, j].Text = "x";
                    }
                    
                    else if (b[i, j] == 61)// the similist way 
                    {

                        c[i, j].BackgroundImage = Properties.Resources.middle_of_ship_down;
                        c[i, j].BackgroundImageLayout = ImageLayout.Zoom;
                    }
                    else if (b[i, j] == 51)// from bottom to top 
                    {

                        c[i, j].BackgroundImage = Properties.Resources.back_of_ship__down;
                        c[i, j].BackgroundImageLayout = ImageLayout.Zoom;
                    }// from bottom to top 
                    else if (b[i, j] == 41)// from btm to top 
                    {
                      
                        c[i, j].BackgroundImage = Properties.Resources.front_of_ship_up;
                        c[i, j].BackgroundImageLayout = ImageLayout.Zoom;
                    }
                    else if (b[i, j] == 62)// the similist way 
                    {
                        c[i, j].BackgroundImage = Properties.Resources.middle_of_ship_down;
                        c[i, j].BackgroundImageLayout = ImageLayout.Zoom;
                    }
                    else if (b[i, j] == 52)// from top to btm 
                    {                                          
                        c[i, j].BackgroundImage = Properties.Resources.back_of_ship_up;
                        c[i, j].BackgroundImageLayout = ImageLayout.Zoom;
                    }// from top to btm 
                    else if (b[i, j] == 42)//from top to bottom  
                    {                       
                        c[i, j].BackgroundImage = Properties.Resources.front_of_ship_down1;
                        c[i, j].BackgroundImageLayout = ImageLayout.Zoom;
                    }
                    else if (b[i, j] == 63) 
                    {
                        c[i, j].BackgroundImage = Properties.Resources.middle_of_ship_;
                        c[i, j].BackgroundImageLayout = ImageLayout.Zoom;
                    }
                    else if (b[i, j] == 53)
                    {
                        c[i, j].BackgroundImage = Properties.Resources.back_of_ship_;
                        c[i, j].BackgroundImageLayout = ImageLayout.Zoom;
                    }
                    else if (b[i, j] == 43)
                    {

                        c[i, j].BackgroundImage = Properties.Resources.front_of_ship_;
                        c[i, j].BackgroundImageLayout = ImageLayout.Zoom;
                    }
                    else if (b[i, j] == 64)
                    {
                        c[i, j].BackgroundImage = Properties.Resources.middle_of_ship_;
                        c[i, j].BackgroundImageLayout = ImageLayout.Zoom;
                    }
                    else if (b[i, j] == 54)
                    {
                        c[i, j].BackgroundImage = Properties.Resources.back_of_ship_up_to_left;
                        c[i, j].BackgroundImageLayout = ImageLayout.Zoom;
                    }
                    else if (b[i, j] == 44)
                    {

                        c[i, j].BackgroundImage = Properties.Resources.front_of_ship_left;
                        c[i, j].BackgroundImageLayout = ImageLayout.Zoom;
                    }
                }
            }          
        }
        private void Form1_Click3(object sender, EventArgs e)//enemy board
        {
            click++;
            turn = 0;
            string k = (((Button)(sender)).Tag).ToString();
            int n = int.Parse(k);
            int shura = n / number; // finds point of button 
            int amuda = n % number;
            if (click % 2 != 0)
            {
                if (board4[shura, amuda] == 10)
                {
                    sendtoplace();
                    checkplace(shura, amuda, board4,1,40);
                }
                else
                {
                    MessageBox.Show("choose a yellow place ");
                    click--;
                }
            }
            else
            { if (board4[shura, amuda] == 5)
                {
                    worked = 0;
                    gotofillin(shura, amuda, board4,sinkingshipsme,40,60,1);
                    for (int i = 0; i < board2.GetLength(0); i++)
                    {
                        for (int j = 0; j < board2.GetLength(1); j++)
                        {
                            if (board4[i, j] == 5)
                                board4[i, j] = 10;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("choose a purople place ");
                    click--;
                }
            }

            updateScreen(board4, boardd);
        }
        private void Form1_Click(object sender, EventArgs e)// enemy guessing board
        {
            string k = (((Button)(sender)).Tag).ToString();
            int n = int.Parse(k);
            int shura = n / number; // finds point of button 
            int amuda = n % number;
            if (board2[shura, amuda] == 40 || board2[shura, amuda] == 50 || board2[shura, amuda] == 60|| board2[shura, amuda] == 15|| (board2[shura, amuda] != 20&& board2[shura, amuda] != 10))
            {
                board3[shura, amuda] = 5;
                board2[shura, amuda] = 15;
                worked = 1;
                sinkingshipsenemy[shura, amuda] = 0;
                MessageBox.Show(" you hit ");
                sendtosinkaship(sinkingshipsenemy,sank);
                winner(sank);
            }
            else if (board2[shura, amuda] != 40 || board2[shura, amuda] != 50 || board2[shura, amuda] != 60||board2[shura, amuda] == 20 || board2[shura, amuda] == 10)
            {
                board3[shura, amuda] = 2;
                MessageBox.Show(" you missed " );
                switchturn();
            }
            updateScreen(board3, boardc);
            updateScreen(board2, boardb);
           
        }
        private void Form1_Click2(object sender, EventArgs e)// my board
        {
            click++;
            string k = (((Button)(sender)).Tag).ToString();           
            int n = int.Parse(k);
            int shura = n / number; // finds point of button 
            int amuda = n %number;
            if (click%2==0)
            {
                if (board2[shura, amuda] == 5)
                {
                    worked = 0;
                    gotofillin(shura, amuda, board2,sinkingshipsenemy,40,60,1);
                    for (int i = 0; i < board2.GetLength(0); i++)
                    {
                        for (int j = 0; j < board2.GetLength(1); j++)
                        {
                            if (board2[i, j] == 5)
                                board2[i, j] = 10;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("choosee as purple plaec ");
                    click--;
                }

            }
            else
            {
                if (board2[shura, amuda] == 10)
                {
                    sendtoplace();
                    checkplace(shura, amuda, board2,1,40);
                }
                else
                {
                    MessageBox.Show(" choose a different place ");
                    click--;
                }
            }                      
            updateScreen(board2, boardb);          
        }
        private void Form1_Click1(object sender, EventArgs e)//my guessing board
        {
            string k = (((Button)(sender)).Tag).ToString();
            int n = int.Parse(k);
            int shura = n / number; // finds point of button 
            int amuda = n % number;
            if (board4[shura, amuda] == 40 || board4[shura, amuda] == 50 || board4[shura, amuda] == 60 || board4[shura, amuda] == 15|| (board4[shura, amuda] != 20 && board4[shura, amuda] != 10))
            {
                board1[shura, amuda] = 5;
                board4[shura, amuda] = 15;
                worked = 1;
                sink = 1;
                sinkingshipsme[shura, amuda] = 0;
                MessageBox.Show(" you hit ");
                sendtosinkaship(sinkingshipsme, sank1);
                winner(sank1);
            }
            else if (board4[shura, amuda] != 40 || board4[shura, amuda] != 50 || board4[shura, amuda] != 60|| board4[shura, amuda] == 20 ||board4[shura, amuda] == 10)
            {
                board1[shura, amuda] = 2;
                MessageBox.Show(" you missed ");
                switchturn();
            }
           
            updateScreen(board1, board);
            updateScreen(board4, boardd);

        }
        void winner(int[]v)
        {
            int win = 1;
            for (int i = 0; i <=4; i++)
            {
                if (v[i] ==0)
                {
                    win = 0;
                    break;
                }
               
            }
            if (win==1)
            {
                MessageBox.Show(" you won" );
                this.Close();
            }
        }
        void gotofillin(int shura,int amuda, int[,] w, int[,] z,int x, int d, int who)
        {
            if (d==0)
            {
                fillin(shura, amuda, 1, 0, w, 1, 0, 0, -1, z, x, d, who,0);
                fillin(shura, amuda, -1, 0, w, -1, 0, 0, -1, z, x, d, who,0);
                fillin(shura, amuda, 0, 1, w, 0, 1, 1, 0, z, x, d, who,0);
                fillin(shura, amuda, 0, -1, w, 0, -1, 1, 0, z, x, d, who,0);
            }
            if (d!=0)
            {
                fillin(shura, amuda, 1, 0, w, 1, 0, 0, -1, z, x, d, who,1);
                fillin(shura, amuda, -1, 0, w, -1, 0, 0, -1, z, x, d, who,2);
                fillin(shura, amuda, 0, 1, w, 0, 1, 1, 0, z, x, d, who,3);
                fillin(shura, amuda, 0, -1, w, 0, -1, 1, 0, z, x, d, who,4);
            }                 
        }
        void fillin(int shura, int amuda, int a, int b, int[,] w , int c, int  d, int g, int f, int[,] z, int x,int y, int who, int dir)
        {  try
            {
                if (w[shura + (piece * a), amuda + (piece * b)] == x)
                {
                    for (int i = 0; i <= piece; i++)
                    {
                        try
                        {                          
                            w[shura + (i * a), amuda + (i * b)] = y+dir;                                                   
                            z[shura + (i * a), amuda + (i * b)] = piece;
                            if (piece == ships-3 && done1 == 0)
                            {
                                z[shura + (i * a), amuda + (i * b)] = piece*(-1);
                                done = 1;
                            }
                        }
                       catch { }
                        try
                        {
                            w[shura + (i * c + g), amuda + (i * d + f)] = 20;
                        }
                        catch { }
                        try
                        {
                            w[shura + (i * c - g), amuda + (i * d - f)] = 20;
                        }
                        catch { }                                                                 
                        }
                        try
                        {
                            w[shura + (piece * a + a), amuda + (piece * b + b)] = 20;
                        }catch { }
                        try
                        {
                            w[shura - a, amuda - b] = 20;
                        }catch { }
                        try
                        {
                            w[shura + (piece * a + a), amuda + (piece * b + b)] = 20;
                        }
                        catch { }
                        try
                        {
                            w[shura - a, amuda - b] = 20;
                        }
                        catch
                        { }
                        if (done==1)
                        {
                            done1 = 1;
                        }
                        if (who==1)
                        {
                            w[shura, amuda] = 50+dir;
                            w[shura + (piece * a), amuda + (piece * b)] = 40+dir;
                        }                      
                }
            }
            catch { }                                         
        }
        void sendtoplace()
        {
            if (time == 0)
            {
                piece = ships-1;
            }
             else if (time == 1)
            {
                piece = ships-2;
            }
            else if (time == 2)
            {             
                piece = ships-3;
            }
            else if (time == 3)
            {               
                piece = ships-3;
            }
            else if (time == 4)
            {               
                piece = ships-4;
            }          
        }
        void markpurple(int shura, int amuda, int a, int d, int[,] b, int f)
        {           
            worked = 0;
            try
            {
                if (b[shura + (piece * a), amuda + (piece * d)] == 10)
                {
                    for (int i = 0; i <= piece; i++)
                    {
                        if (b[shura + (i * a), amuda + (i * d)] ==f|| b[shura + (i * a), amuda + (i * d)] == 20)
                        {
                            worked = 1;
                            break;
                        }
                    }
                    if (worked==0)
                    {
                        b[shura + (piece * a), amuda + (piece * d)] = 5;
                        yes = 1;
                    }                  
                }              
            }
            catch { }
        }
        void checkplace(int shura,int amuda,int [,] b , int f, int w )
        {          
            if ((b[shura, amuda] == 10|| board5[shura, amuda] == 0) && time <= 4)
            {
                b[shura, amuda] = w;
                //updateScreen(board2, boardb);
                time++;
                turn = 0;
                yes = 0;
                markpurple(shura, amuda, -1, 0,b,f);
                markpurple(shura, amuda, 1, 0, b,f);
                markpurple(shura, amuda, 0, 1, b,f);
                markpurple(shura, amuda, 0, -1, b,f);
                ugh1 = 0;
                if (yes == 0)
                {
                    b[shura, amuda] = 10;
                    MessageBox.Show("choose a different place ");
                    time--;                    
                    ugh1 = 1;                    
                }
            }
            else                                       
            {
                MessageBox.Show(" you have finished building the ships");
                start++;
                switchturn();
                click = 0;
                time = 0;
                turn = 1;
            }

        }      
        void sendtosinkaship (int[,]w, int[] v)
        {       
            sinkaship(w, ships - 1,0,v);
            sinkaship(w, ships - 2,1,v);
            sinkaship(w, (ships - 3)*(-1),2,v);
            sinkaship(w, ships - 3,3,v);
            sinkaship(w, ships - 4,4,v);
        }
        void sinkaship(int[,] w, int z,int l, int[] v)
        {         
            int sunk = 1;
            for (int i = 0; i <w.GetLength(0); i++)
            {
                for (int j = 0; j < w.GetLength(1); j++)
                {
                    if (w[i,j]==z)
                    {
                        sunk = 0;
                        break;
                    }
                }
            }
            if (sunk==1)
            {                               
                if (v[l]==0)
                {                 
                    int y = Math.Abs(z) + 1;
                    MessageBox.Show(" you have sunken the ship made of  " + y + "   pieces ");
                }                         
                v[l] = 1;
            }           
        }
        void switchturn ()
        {
            MessageBox.Show("switching turn");
            done = 0;
            done1 = 0;
            if (start >= 2)

            {
                if (panel2.Visible == true)
                {
                    panel1.Visible = false;
                    panel2.Visible = false;
                }
                else if (panel2.Visible == false)
                {
                    panel1.Visible = true;
                    panel2.Visible = true;
                }
                if (panel4.Visible == true)
                {
                    panel3.Visible = false;
                    panel4.Visible = false;
                }
                else if (panel4.Visible == false)
                {
                    panel3.Visible = true;
                    panel4.Visible = true;
                }
            }
            else if (start<=2)
            {

                if (panel2.Visible == true)
                {                   
                    panel2.Visible = false;
                }
                else if (panel2.Visible == false)
                {                    
                    panel2.Visible = true;
                }
                if (panel4.Visible == true)
                {                    
                    panel4.Visible = false;
                }
                else if (panel4.Visible == false)
                {                   
                    panel4.Visible = true;
                }

            }
        }
        #endregion region 
        #region the computer puts the ships 
        private void button8_Click(object sender, EventArgs e)
        {
            {
                label1.Visible = false;
                label2.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                button8.Visible = false;
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = false;
                panel5.Visible = true;
                string s = textBox1.Text; //what is in the text box                        //MessageBox.Show(s); // show s
                number = int.Parse(s);
                string t = textBox2.Text; //what is in the text box                        //MessageBox.Show(s); // show s
                ships = int.Parse(t);
                boarde = new Button[number, number];
                board5 = new int[number, number];
                sank = new int[5];
                sank1 = new int[5];
                sinkingshipsme = new int[number, number];
                sinkingshipsenemy = new int[number, number];
                int guesses = 0;
                int r, c;
                r = 0;
                int num = 0;
                panel5.Width = number * 40; // makes it squares 
                panel5.Height = number * 40;
                while (r < boarde.GetLength(0))
                {
                    c = 0;
                    while (c < boarde.GetLength(1))
                    {
                        boarde[r, c] = new Button();
                        board5[r, c] = 10;
                        boarde[r, c].Size = new Size(panel5.Width / number, panel5.Height / number);
                        boarde[r, c].Location = new Point(c * panel5.Width / number, r * panel5.Height / number);
                        boarde[r, c].Tag = num;// new thing to be abe to press the button 
                        num++;
                        boarde[r, c].Click += Form1_Click5;
                        panel5.Controls.Add(boarde[r, c]);
                        c++;
                    }
                    r++;
                }
            }// simple set up            
             compsetup();
            //updateScreen(board5, boarde);
        }// computer put the ships and the human guesses 
        void compsetup()
        {
            for (int p = 5; p > 0; p--)
            {              
                guess();
                sendtoplace();             
                checkplace(i, j, board5,0,1);
                if (ugh1==0)
                {
                    for (int d = 0; d < board5.GetLength(0); d++)
                    {
                        for (int f = 0; f < board5.GetLength(1); f++)
                        {
                            if (board5[d, f] == 5)
                            {
                                gotofillin(d, f, board5, sinkingshipsenemy,1,0,0);
                                break;
                            }
                        }
                    }                   
                }
                else if (ugh1==1)              
                {
                    p++;                   
                }
                
            }
            for (int d = 0; d < board5.GetLength(0); d++)
            {
                for (int f = 0; f < board5.GetLength(1); f++)
                {
                    if (board5[d, f] == 5)
                    {
                        board5[d, f] = 10;
                    }
                }
            }
            //updateScreen(board5, boarde);
            MessageBox.Show("the board is ready start playing !!!!!!!!!!!!!!!!!!!!!!");
        }       
        void guess()
        {
            try
            {               
                i = ran.Next(board5.GetLength(0) );
                j = ran.Next(board5.GetLength(1));
                if (board5[i, j] == 10)
                {
                    board5[i, j] = 0;                  
                    lasti = i;
                    lastj = j;
                }
                else
                {
                    guess();// recursia
                }
            }catch { }
        }       
        private void Form1_Click5(object sender, EventArgs e)
        {
            string k = (((Button)(sender)).Tag).ToString();
            int n = int.Parse(k);
            int shura = n / number; // finds point of button 
            int amuda = n % number;
            guesshuman++;
            if (board5[shura, amuda] == 0)
            {
                board5[shura, amuda] = 1000;
                //MessageBox.Show("you hit");
                sinkingshipsenemy[shura, amuda] = 0;
                MessageBox.Show(" you hit ");
                sendtosinkaship(sinkingshipsenemy, sank);
            }
            else if (board5[shura, amuda] == 1000)
            {
                board5[shura, amuda] = 1000;               
            }
            else if (board5[shura, amuda] != 0)
            {
                board5[shura, amuda] = 2;
               // MessageBox.Show("you missed");
            }            
            updateScreencomp(board5, boarde);
        }
# endregion
        #region computer guesses place of ships 
        private void button2_Click_1(object sender, EventArgs e)// computer guesses where you ships are 
        {
            label1.Visible = false;
            label2.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button8.Visible = false;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            button4.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = true;          
            string s = textBox1.Text; //what is in the text box                        //MessageBox.Show(s); // show s
            number = int.Parse(s);
            string t = textBox2.Text; //what is in the text box                        //MessageBox.Show(s); // show s
            ships = int.Parse(t);
            boarde = new Button[number, number];
            board5 = new int[number, number];
            int guesses = 0;
            int r, c;
            r = 0;
            int num = 0;
            panel5.Width = number * 40; // makes it squares 
            panel5.Height = number * 40;
            while (r < boarde.GetLength(0))
            {
                c = 0;
                while (c < boarde.GetLength(1))
                {
                    boarde[r, c] = new Button();
                    board5[r, c] = 10;
                    boarde[r, c].Size = new Size(panel5.Width / number, panel5.Height / number);
                    boarde[r, c].Location = new Point(c * panel5.Width / number, r * panel5.Height / number);
                    boarde[r, c].Tag = num;// new thing to be abe to press the button 
                    num++;
                    
                    panel5.Controls.Add(boarde[r, c]);
                    c++;
                }
                r++;
            }
            updateScreen(board5, boarde);
        }     
        private void button7_Click(object sender, EventArgs e)
        {            
            hit = 0;
        }
        private void button5_Click(object sender, EventArgs e)// computer guess
        {
            if (hit==0&&hit1==0)
            {
                guess();
            }
            else if (hit == 1 && hit1 == 0)
            {              
                set = 0;
                guessnieghbor(0, 1);
                if (set == 0)
                {
                    guessnieghbor(0, -1);
                    if (set == 0)
                    {
                        guessnieghbor(1, 0);
                        if (set == 0)
                        {
                            guessnieghbor(-1, 0);
                        }
                    }
                }
            }
            else if (hit == 0 && hit1 == 1)
            {               
                set = 0;
                guessnieghbor1 (- movementi, -movementj);
                if (set == 0)
                {
                    guessnieghbor1(0, -1);
                    if (set == 0)
                    {
                        guessnieghbor1(1, 0);
                        if (set == 0)
                        {
                            guessnieghbor1(-1, 0);
                            if (set == 0)
                            {
                                guessnieghbor1(0, 1);
                                if (set==0)
                                {
                                    MessageBox.Show("Lair");

                                }
                            }
                        }
                    }
                }
            }
            else if (hit == 1 && hit1 == 1)
            {      
                set = 0;
                guessnieghbor3(movementi, movementj);
                if (set == 0)
                {
                    guessnieghbor1(-movementi, -movementj);                  
                }
            }
            updateScreen(board5, boarde);            
        }
        void guessnieghbor(int x,int y)
        { 
            try
            {
                if (board5[lasti + x, lastj + y] == 10)
                {
                    board5[lasti + x, lastj + y] = 0;
                    set = 1;
                    movementi = x;
                    movementj = y;
                    lasti = lasti + x;
                    lastj = lastj + y;
                }             
                updateScreen(board5, boarde);
            }
            catch { }
        }
        void guessnieghbor3(int x, int y)
        {
            try
            {
                if (board5[lasti + x, lastj + y] == 10)
                {
                    board5[lasti + x, lastj + y] = 0;
                    set = 1;                   
                    lasti = lasti + x;
                    lastj = lastj + y;
                }
                updateScreen(board5, boarde);
            }
            catch { }
        }
        void guessnieghbor1(int x, int y)
        {
            try
            {
                if (board5[i + x, j + y] == 10)
                {
                    board5[i + x, j + y] = 0;
                    set = 1;
                    movementi = x;
                    movementj = y;
                    lasti = i + x;
                    lastj = j + y;
                }
                updateScreen(board5, boarde);
            }
            catch { }
        }
        private void button6_Click(object sender, EventArgs e)// computer hit 
        {          
            board5[lasti, lastj] = 20;
            updateScreen(board5, boarde);
            hit1 = 1;
            hit = 1;
        }
        void updateScreencomp(int[,] b, Button[,] c)
        {
            int red = 0;
            for (int i = 0; i < b.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    if (b[i, j] == 1000)
                    {
                        c[i, j].BackColor = Color.Red;
                        red++;                       
                    }
                    else if (b[i, j] == 2)
                    {
                        c[i, j].BackColor = Color.White;
                       
                    }
                    else if (b[i, j] == 500)
                    {
                        c[i, j].BackColor = Color.Purple;                        
                    }                  
                }
                if (red==ships*5-8)
                {
                    MessageBox.Show("great job you won you guessed  "+ guesshuman+ " times " );
                    this.Close();
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            hit1 = 0;
            hit = 0;
            for (int i = 0; i < board5.GetLength(0); i++)
            {
                for (int j = 0; j < board5.GetLength(0); j++)
                {
                    if (board5[i,j]==20)
                    {
                        makearoundblue(i, j, 1, 0);
                        makearoundblue(i, j, -1, 0);
                        makearoundblue(i, j, 0, 1);
                        makearoundblue(i, j, 0, -1);
                    }
                }

            }
            updateScreen(board5, boarde);
        }// sunk a ship 
        void makearoundblue (int i, int j, int x, int y)
        {
            try
            {
                if (board5[i + x, j + y] == 10 || board5[i + x, j + y] == 0)
                {
                    board5[i + x, j + y] = 5;
                }
            }catch { }
        }
        #endregion
        #region extra 
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }       
        public Form1()
        {
            InitializeComponent();
        }
        void buildboard(int[,] b, Button[,] k,Panel f,int g)
        {
            int number = 8;
            k = new Button[number, number];
            b = new int[number, number];
            int num = 0;
            f.Width = number * 40; // makes it squares 
            f.Height = number * 40;
            for (int r = 0; r < k.GetLength(0); r++)
            {
                for (int c = 0; c < k.GetLength(1); c++)
                {
                    k[r, c] = new Button();                   
                    b[r, c] = g;
                    k[r, c].Size = new Size(f.Width / number, f.Height / number);
                    k[r, c].Location = new Point(c * f.Width / number, r * f.Height / number);
                    k[r, c].Tag = num;// new thing to be abe to press the button 
                    num++;
                    k[r, c].Click += Form1_Click4;
                    f.Controls.Add(k[r, c]);
                }
            }
        }
        private void Form1_Click4(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

       
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        #endregion

    }
}
