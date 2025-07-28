using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJackGame
{
    public partial class Form2 : Form
    {

        Dictionary<string, Image> deck = new Dictionary<string, Image>();
        Dictionary<string, int> cardValues = new Dictionary<string, int>();

        List<string> availableCards = new List<string>();
        List<string> playerCards = new List<string>();
        List<string> dealerCards = new List<string>();

        Random randomNumber = new Random();

        PictureBox dealerCard;
        PictureBox playerCard;
        PictureBox standButton;
        PictureBox hitButton;
        PictureBox playAgainButton;
        PictureBox mainMenu;

        Label resultLabel;
        Label playerPointLabel;
        Label dealerPointLabel;

        SoundPlayer cardSound;

        string[] allCards;
        string hiddenCard = "";

        int playerCardX = 0;
        int dealerCardX = 0;
        int playerCardY = 0;
        int dealerCardY = 0;

        int step = 0;

        public Form2()
        {
            InitializeComponent();

            Stream cursor = new MemoryStream(Resources.cursor);
            this.Cursor = new Cursor(cursor);

            this.FormClosed += Form2_FormClosed;

        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {

            Application.Exit();

        }

        private void LoadCards()
        {
            deck["2_of_clubs"] = Resources.card2_of_clubs;
            deck["2_of_diamonds"] = Resources.card2_of_diamonds;
            deck["2_of_hearts"] = Resources.card2_of_hearts;
            deck["2_of_spades"] = Resources.card2_of_spades;

            deck["3_of_clubs"] = Resources.card3_of_clubs;
            deck["3_of_diamonds"] = Resources.card3_of_diamonds;
            deck["3_of_hearts"] = Resources.card3_of_hearts;
            deck["3_of_spades"] = Resources.card3_of_spades;

            deck["4_of_clubs"] = Resources.card4_of_clubs;
            deck["4_of_diamonds"] = Resources.card4_of_diamonds;
            deck["4_of_hearts"] = Resources.card4_of_hearts;
            deck["4_of_spades"] = Resources.card4_of_spades;

            deck["5_of_clubs"] = Resources.card5_of_clubs;
            deck["5_of_diamonds"] = Resources.card5_of_diamonds;
            deck["5_of_hearts"] = Resources.card5_of_hearts;
            deck["5_of_spades"] = Resources.card5_of_spades;

            deck["6_of_clubs"] = Resources.card6_of_clubs;
            deck["6_of_diamonds"] = Resources.card6_of_diamonds;
            deck["6_of_hearts"] = Resources.card6_of_hearts;
            deck["6_of_spades"] = Resources.card6_of_spades;

            deck["7_of_clubs"] = Resources.card7_of_clubs;
            deck["7_of_diamonds"] = Resources.card7_of_diamonds;
            deck["7_of_hearts"] = Resources.card7_of_hearts;
            deck["7_of_spades"] = Resources.card7_of_spades;

            deck["8_of_clubs"] = Resources.card8_of_clubs;
            deck["8_of_diamonds"] = Resources.card8_of_diamonds;
            deck["8_of_hearts"] = Resources.card8_of_hearts;
            deck["8_of_spades"] = Resources.card8_of_spades;

            deck["9_of_clubs"] = Resources.card9_of_clubs;
            deck["9_of_diamonds"] = Resources.card9_of_diamonds;
            deck["9_of_hearts"] = Resources.card9_of_hearts;
            deck["9_of_spades"] = Resources.card9_of_spades;

            deck["10_of_clubs"] = Resources.card10_of_clubs;
            deck["10_of_diamonds"] = Resources.card10_of_diamonds;
            deck["10_of_hearts"] = Resources.card10_of_hearts;
            deck["10_of_spades"] = Resources.card10_of_spades;

            deck["jack_of_clubs"] = Resources.jack_of_clubs2;
            deck["jack_of_diamonds"] = Resources.jack_of_diamonds2;
            deck["jack_of_hearts"] = Resources.jack_of_hearts2;
            deck["jack_of_spades"] = Resources.jack_of_spades2;

            deck["queen_of_clubs"] = Resources.queen_of_clubs2;
            deck["queen_of_diamonds"] = Resources.queen_of_diamonds2;
            deck["queen_of_hearts"] = Resources.queen_of_hearts2;
            deck["queen_of_spades"] = Resources.queen_of_spades2;

            deck["king_of_clubs"] = Resources.king_of_clubs2;
            deck["king_of_diamonds"] = Resources.king_of_diamonds2;
            deck["king_of_hearts"] = Resources.king_of_hearts2;
            deck["king_of_spades"] = Resources.king_of_spades2;

            deck["ace_of_clubs"] = Resources.ace_of_clubs;
            deck["ace_of_diamonds"] = Resources.ace_of_diamonds;
            deck["ace_of_hearts"] = Resources.ace_of_hearts;
            deck["ace_of_spades"] = Resources.ace_of_spades2;

            deck["closedcard"] = Resources.closedcard;

            allCards = deck.Keys.Where(k => k != "closedcard").ToArray();
            availableCards = deck.Keys.Where(k => k != "closedcard").ToList();
        }

        private void LoadCardValues()
        {
            // 2-10

            for (int i = 2; i <= 10; i++)
            {
                string num = i.ToString();

                cardValues[$"{num}_of_clubs"] = i;
                cardValues[$"{num}_of_diamonds"] = i;
                cardValues[$"{num}_of_hearts"] = i;
                cardValues[$"{num}_of_spades"] = i;
            }

            // J, Q, K = 10

            string[] faces = { "jack", "queen", "king" };

            for (int i = 0; i < faces.Length; i++)
            {
                string num = faces[i];
                cardValues[$"{num}_of_clubs"] = 10;
                cardValues[$"{num}_of_diamonds"] = 10;
                cardValues[$"{num}_of_hearts"] = 10;
                cardValues[$"{num}_of_spades"] = 10;
            }

            // Ace = Now 11

            cardValues["ace_of_clubs"] = 11;
            cardValues["ace_of_diamonds"] = 11;
            cardValues["ace_of_hearts"] = 11;
            cardValues["ace_of_spades"] = 11;
        }
        private string getRandomCard()
        {

            while (true)
            {

                int index = randomNumber.Next(availableCards.Count);

                string selectedCard = availableCards[index];

                availableCards.RemoveAt(index);

                return selectedCard;

            }
        }

        private void addCardPlayer(Image cardImage)
        {

            PictureBox cards = new PictureBox();

            cards.Image = cardImage;

            cards.Size = new Size(170, 240);
            cards.SizeMode = PictureBoxSizeMode.StretchImage;
            cards.Location = new Point(playerCardX, playerCardY);

            playerCardX += 45;

            this.Controls.Add(cards);

            cards.BringToFront();

            cardSound.Play();

            calculatePointPlayer();

        }

        private void addCardDealer(Image cardImage)
        {

            PictureBox cards = new PictureBox();

            cards.Image = cardImage;

            cards.Size = new Size(170, 240);
            cards.SizeMode = PictureBoxSizeMode.StretchImage;
            cards.Location = new Point(dealerCardX, dealerCardY);

            dealerCardX += 45;

            this.Controls.Add(cards);

            cards.BringToFront();

            cardSound.Play();

            calculatePointDealer();
        }

        private int calculateValue(List<string> deck)
        {

            int total = 0;
            int ace = 0;

            for (int i = 0; i < deck.Count; i++)
            {

                string card = deck[i];

                if (cardValues.ContainsKey(card))
                {

                    int value = cardValues[card];

                    total += value;

                    if (card.StartsWith("ace"))
                    {

                        ace++;

                    }

                }

            }

            while (total > 21 && ace > 0)
            {

                total -= 10;
                ace--;

            }

            return total;

        }

        private void calculateResult(int dealerTotalPoint)
        {

            int playerTotalPoint = calculateValue(playerCards);


            if (playerTotalPoint > 21)
            {

                resultLabel.Text = "YOU LOSE!";

                calculatePointDealer();
                calculatePointPlayer();

            }

            else if (dealerTotalPoint > 21)
            {

                resultLabel.Text = "YOU WIN!";

                calculatePointDealer();
                calculatePointPlayer();

            }

            else if (playerTotalPoint == 21 && dealerTotalPoint == 21)
            {

                resultLabel.Text = "IT'S A TIE!";

                calculatePointDealer();
                calculatePointPlayer();

            }

            else if (playerTotalPoint == 21)
            {

                resultLabel.Text = "YOU WIN!";

                calculatePointDealer();
                calculatePointPlayer();

            }

            else if (playerTotalPoint > dealerTotalPoint)
            {

                resultLabel.Text = "YOU WIN!";

                calculatePointDealer();
                calculatePointPlayer();

            }

            else if (playerTotalPoint < dealerTotalPoint)
            {

                resultLabel.Text = "YOU LOSE!";

                calculatePointDealer();
                calculatePointPlayer();

            }

            else
            {

                resultLabel.Text = "IT'S A TIE!";

                calculatePointDealer();
                calculatePointPlayer();

            }

            resultLabel.Visible = true;
            playAgainButton.Visible = true;

            hitButton.Enabled = false;
            standButton.Enabled = false;

            hitButton.Visible = false;
            standButton.Visible = false;

        }

        private void restartGame()
        {

            for (int i = this.Controls.Count - 1; i >= 0; i--)
            {

                Control c = this.Controls[i];

                if (c is PictureBox)
                {

                    if (c != hitButton && c != standButton && c != playAgainButton && c != mainMenu)
                    {

                        this.Controls.Remove(c);
                        c.Dispose();

                    }
                }
            }

            playerCards.Clear();
            dealerCards.Clear();
            availableCards = allCards.ToList();

            playerCardX = dealerCardX = (this.ClientSize.Width - 190) / 2;

            hiddenCard = "";
            dealerCard = null;

            resultLabel.Visible = false;
            resultLabel.Text = "";

            playerPointLabel.Text = "";
            dealerPointLabel.Text = "";

            playAgainButton.Visible = false;
            standButton.Visible = true;
            hitButton.Visible = true;

            hitButton.Enabled = false;
            standButton.Enabled = false;

            step = 0;

            timer1.Start();

        }

        private void calculatePointPlayer()
        {

            int playerTotalPoint = calculateValue(playerCards);

            playerPointLabel.Text = Convert.ToString(playerTotalPoint);

        }
        private void calculatePointDealer()

        {
            if (step == 4)
            {

                step++;

            }

            else
            {

                int dealerTotalPoint = calculateValue(dealerCards);

                dealerPointLabel.Text = Convert.ToString(dealerTotalPoint);

            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {

            LoadCards();
            LoadCardValues();

            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            //Main Menu Button//

            mainMenu = new PictureBox();

            cardSound = new SoundPlayer(Resources.carddeal);

            mainMenu.Image = Resources.menubutton;
            mainMenu.SizeMode = PictureBoxSizeMode.StretchImage;

            mainMenu.Width = 48;
            mainMenu.Height = 48;
            mainMenu.Top = 20;
            mainMenu.Left = this.ClientSize.Width - mainMenu.Width - 20;

            mainMenu.MouseEnter += (s, e) =>
            {

                mainMenu.Image = Resources.mainmenuhoverbutton;

                Stream hoverCursor = new MemoryStream(Resources.cursorhover);
                this.Cursor = new Cursor(hoverCursor);

            };

            mainMenu.MouseLeave += (s, e) =>
            {

                mainMenu.Image = Resources.menubutton;

                Stream normalCursor = new MemoryStream(Resources.cursor);
                this.Cursor = new Cursor(normalCursor);

            };

            mainMenu.Click += (s, e) =>
            {

                cardSound.Stop();

                timer1.Stop();
                timer2.Stop();
                timer3.Stop();

                Form1 form1 = new Form1();

                form1.Show();

                this.Hide();

            };

            this.Controls.Add(mainMenu);

            //Player-Dealer Cards//

            int totalCardWidth = 190;
            int centerX = (this.ClientSize.Width - totalCardWidth) / 2;
            int centerY = this.ClientSize.Height - 200;
            int space = 1000;

            playerCardY = this.ClientSize.Height - 300;
            dealerCardY = 120;

            playerCardX = centerX;
            dealerCardX = centerX;

            //availableCards = deck.Keys.Where(k => k != "closedcard").ToList();

            timer1.Start();

            //Result Label//

            resultLabel = new Label();

            resultLabel.AutoSize = false;
            resultLabel.TextAlign = ContentAlignment.MiddleCenter;
            resultLabel.Font = new Font("Arial", 32, FontStyle.Bold);
            resultLabel.ForeColor = Color.White;
            resultLabel.BackColor = Color.FromArgb(180, 0, 0, 0);

            resultLabel.Size = new Size(500, 100);
            resultLabel.Location = new Point((this.ClientSize.Width - resultLabel.Width) / 2, (this.ClientSize.Height - resultLabel.Height) / 2);

            resultLabel.Visible = false;

            this.Controls.Add(resultLabel);

            //Point Label//

            //PLAYER//

            playerPointLabel = new Label();

            playerPointLabel.AutoSize = false;
            playerPointLabel.TextAlign = ContentAlignment.MiddleCenter;

            playerPointLabel.Font = new Font("Arial", 24, FontStyle.Bold);
            playerPointLabel.ForeColor = Color.White;
            playerPointLabel.BackColor = Color.FromArgb(180, 0, 0, 0);

            playerPointLabel.Size = new Size(80, 80);

            playerPointLabel.Location = new Point((this.ClientSize.Width - playerPointLabel.Width) / 2 - 250, playerCardY);

            this.Controls.Add(playerPointLabel);

            //Dealer//

            dealerPointLabel = new Label();

            dealerPointLabel.AutoSize = false;
            dealerPointLabel.TextAlign = ContentAlignment.MiddleCenter;

            dealerPointLabel.Font = new Font("Arial", 24, FontStyle.Bold);
            dealerPointLabel.ForeColor = Color.White;
            dealerPointLabel.BackColor = Color.FromArgb(180, 0, 0, 0);

            dealerPointLabel.Size = new Size(80, 80);

            dealerPointLabel.Location = new Point((this.ClientSize.Width - dealerPointLabel.Width) / 2 - 250, dealerCardY);

            this.Controls.Add(dealerPointLabel);

            //Play Agian Button//

            playAgainButton = new PictureBox();

            playAgainButton.Image = Resources.playagain;

            playAgainButton.Size = new Size(200, 80);
            playAgainButton.SizeMode = PictureBoxSizeMode.StretchImage;

            playAgainButton.Location = new Point((this.ClientSize.Width - playAgainButton.Width) / 2, resultLabel.Bottom + 30);

            playAgainButton.Visible = false;

            playAgainButton.MouseEnter += (s, e) =>
            {

                playAgainButton.Image = Resources.playagainhover;

                this.Cursor = new Cursor(new MemoryStream(Resources.cursorhover));

            };

            playAgainButton.MouseLeave += (s, e) =>
            {

                playAgainButton.Image = Resources.playagain;

                this.Cursor = new Cursor(new MemoryStream(Resources.cursor));

            };

            playAgainButton.Click += (s, e) =>
            {

                restartGame();

            };

            this.Controls.Add(playAgainButton);

            //Stand Button//

            standButton = new PictureBox();

            standButton.Image = Resources.standbutton;

            standButton.Size = new Size(160, 80);
            standButton.SizeMode = PictureBoxSizeMode.StretchImage;

            standButton.Location = new Point(this.ClientSize.Width / 2 + space / 2, centerY);

            standButton.Enabled = false;

            standButton.MouseEnter += (s, e) =>
            {

                standButton.Image = Resources.standbuttonhover;

                this.Cursor = new Cursor(new MemoryStream(Resources.cursorhover));

            };

            standButton.MouseLeave += (s, e) =>
            {

                standButton.Image = Resources.standbutton;

                this.Cursor = new Cursor(new MemoryStream(Resources.cursor));

            };

            standButton.Click += (s, e) =>
            {

                standButton.Enabled = false;
                hitButton.Enabled = false;

                if (dealerCard != null)
                {

                    this.Controls.Remove(dealerCard);

                    dealerCard.Dispose();

                    dealerCard = null;

                    addCardDealer(deck[hiddenCard]);

                }

                int dealerTotalPoint = calculateValue(dealerCards);

                if (dealerTotalPoint < 17)
                {

                    timer2.Start();

                }

                else
                {

                    calculateResult(dealerTotalPoint);

                }

            };

            this.Controls.Add(standButton);

            //Hit Button//

            hitButton = new PictureBox();

            hitButton.Image = Resources.hitbutton;

            hitButton.Size = new Size(160, 80);
            hitButton.SizeMode = PictureBoxSizeMode.StretchImage;

            hitButton.Location = new Point(this.ClientSize.Width / 2 - 160 - space / 2, centerY);

            hitButton.Enabled = false;

            hitButton.MouseEnter += (s, e) =>
            {

                hitButton.Image = Resources.hitbuttonhover;

                this.Cursor = new Cursor(new MemoryStream(Resources.cursorhover));

            };

            hitButton.MouseLeave += (s, e) =>
            {

                hitButton.Image = Resources.hitbutton;

                this.Cursor = new Cursor(new MemoryStream(Resources.cursor));

            };

            hitButton.Click += (s, e) =>
            {

                hitButton.Enabled = false;
                standButton.Enabled = false;

                timer3.Start();

            };

            this.Controls.Add(hitButton);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            string cardName;
            Image cardImage;

            if (step == 0 || step == 2)
            {

                cardName = getRandomCard();
                cardImage = deck[cardName];

                playerCards.Add(cardName);
                addCardPlayer(cardImage);


            }

            else if (step == 1)
            {

                cardName = getRandomCard();
                cardImage = deck[cardName];

                dealerCards.Add(cardName);
                addCardDealer(cardImage);


            }

            else if (step == 3)
            {

                hiddenCard = getRandomCard();

                dealerCards.Add(hiddenCard);

                dealerCard = new PictureBox();

                dealerCard.Image = deck["closedcard"];

                dealerCard.Size = new Size(170, 240);
                dealerCard.SizeMode = PictureBoxSizeMode.StretchImage;

                dealerCard.Location = new Point(dealerCardX, dealerCardY);

                dealerCardX += 45;

                this.Controls.Add(dealerCard);

                dealerCard.BringToFront();

                cardSound.Play();

            }

            step++;

            if (step >= 4)
            {

                timer1.Stop();

                hitButton.Enabled = true;
                standButton.Enabled = true;

                calculatePointPlayer();
                calculatePointDealer();

                int playerPoints = calculateValue(playerCards);

                if (playerPoints == 21 && playerCards.Count == 2)
                {

                    resultLabel.Text = "BLACKJACK!";

                    resultLabel.Visible = true;
                    playAgainButton.Visible = true;

                    hitButton.Enabled = false;
                    standButton.Enabled = false;

                }

            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            string cardName = getRandomCard();

            addCardDealer(deck[cardName]);

            dealerCards.Add(cardName);

            int dealerTotalPoint = calculateValue(dealerCards);

            if (dealerTotalPoint < 17)
            {

            }

            else
            {

                timer2.Stop();

                calculateResult(dealerTotalPoint);

            }

        }

        private void timer3_Tick(object sender, EventArgs e)
        {

            string newCardName = getRandomCard();

            playerCards.Add(newCardName);

            addCardPlayer(deck[newCardName]);

            int playerTotalPoint = calculateValue(playerCards);
            int dealerTotalPoint = calculateValue(dealerCards);

            if (playerTotalPoint >= 21)
            {

                timer3.Stop();

                if (dealerCard != null)
                {

                    this.Controls.Remove(dealerCard);

                    dealerCard.Dispose();

                    dealerCard = null;

                }

                addCardDealer(deck[hiddenCard]);

                calculateResult(dealerTotalPoint);

            }

            else
            {

                hitButton.Enabled = true;
                standButton.Enabled = true;

                timer3.Stop();

            }


        }
    }
}
