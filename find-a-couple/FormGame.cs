﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace find_a_couple
{
    public partial class FormGame : Form
    {
        int[] pairs;
        int[] opened;
        int[] gamePairs;
        int stepsCounter;
        int winCheck;
        PictureBox[] picBoxArray;
        int openedCount;
        public FormGame()
        {
            InitializeComponent();
            pairs = new int[10];
            gamePairs = new int[20];
            opened = new int[2];
            openedCount = 0;
            picBoxArray = new PictureBox[20];
            picBoxArray[0] = pictureBox1;
            picBoxArray[1] = pictureBox2;
            picBoxArray[2] = pictureBox3;
            picBoxArray[3] = pictureBox4;
            picBoxArray[4] = pictureBox5;
            picBoxArray[5] = pictureBox6;
            picBoxArray[6] = pictureBox7;
            picBoxArray[7] = pictureBox8;
            picBoxArray[8] = pictureBox9;
            picBoxArray[9] = pictureBox10;
            picBoxArray[10] = pictureBox11;
            picBoxArray[11] = pictureBox12;
            picBoxArray[12] = pictureBox13;
            picBoxArray[13] = pictureBox14;
            picBoxArray[14] = pictureBox15;
            picBoxArray[15] = pictureBox16;
            picBoxArray[16] = pictureBox17;
            picBoxArray[17] = pictureBox18;
            picBoxArray[18] = pictureBox19;
            picBoxArray[19] = pictureBox20;       
        }
        public void CardsHide()
        {
            pictureBox1.BackgroundImage = imageList1.Images[10];
            pictureBox2.BackgroundImage = imageList1.Images[10];
            pictureBox3.BackgroundImage = imageList1.Images[10];
            pictureBox4.BackgroundImage = imageList1.Images[10];
            pictureBox5.BackgroundImage = imageList1.Images[10];
            pictureBox6.BackgroundImage = imageList1.Images[10];
            pictureBox7.BackgroundImage = imageList1.Images[10];
            pictureBox8.BackgroundImage = imageList1.Images[10];
            pictureBox9.BackgroundImage = imageList1.Images[10];
            pictureBox10.BackgroundImage = imageList1.Images[10];
            pictureBox11.BackgroundImage = imageList1.Images[10];
            pictureBox12.BackgroundImage = imageList1.Images[10];
            pictureBox13.BackgroundImage = imageList1.Images[10];
            pictureBox14.BackgroundImage = imageList1.Images[10];
            pictureBox15.BackgroundImage = imageList1.Images[10];
            pictureBox16.BackgroundImage = imageList1.Images[10];
            pictureBox17.BackgroundImage = imageList1.Images[10];
            pictureBox18.BackgroundImage = imageList1.Images[10];
            pictureBox19.BackgroundImage = imageList1.Images[10];
            pictureBox20.BackgroundImage = imageList1.Images[10];
        }

        private void FormGame_Load(object sender, EventArgs e)
        {
            CardsHide();
            newGameToolStripMenuItem_Click(null, null);
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CardsHide();
            winCheck = 0;
            stepsCounter = 0;
            labelSteps.Text = "Количество ходов: " + stepsCounter.ToString();
            openedCount = 0;
            Random rnd;
            rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                pairs[i] = rnd.Next(10);

            }
            for (int i = 0; i < 20; i++) 
            {
                picBoxArray[i].Visible = true;
                gamePairs[i] = -1;
            }
            int usedPairs = 0;
            while (usedPairs != 10)
            { 
                int num1 = rnd.Next(20), num2 = rnd.Next(20);
                if (num1 == num2) continue;
                if (gamePairs[num1] == -1 && gamePairs[num2] == -1)
                {
                    gamePairs[num1] = gamePairs[num2] = pairs[usedPairs]; 
                    usedPairs++;
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender; // Универсальный тип-объект преобразовываем в конкретный
            int index = Convert.ToInt32(p.Tag); // Присваиваем индексам номера тегов
            if (openedCount == 1) // Проверка на нажатие одной и той же карточки дважды
            {
                if (opened[0] == index) return;
            }
            if (openedCount == 2)
            {
                stepsCounter++;
                labelSteps.Text = "Количество ходов: " + stepsCounter.ToString();
                CardsHide();
                openedCount = 0;              
            }
            opened[openedCount] = index; // Фиксируем тег открытой картинки
            openedCount++; 
            if (openedCount == 2)
            {
                if (gamePairs[opened[0]] == gamePairs[opened[1]])
                {
                    stepsCounter++;
                    labelSteps.Text = "Количество ходов: " + stepsCounter.ToString();
                    picBoxArray[opened[0]].Visible = false; // Скрываем верно открытые картинки
                    picBoxArray[opened[1]].Visible = false;
                    winCheck++;
                    openedCount = 0;
                    stepsCounter++;                  
                }
            }
            if (winCheck == 10) MessageBox.Show("Победа!");
            p.BackgroundImage = imageList1.Images[gamePairs[index]];           
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           Process.Start("https://github.com/dexttra");
        }

     
    }
}
