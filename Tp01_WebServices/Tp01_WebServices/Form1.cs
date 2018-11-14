using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;

namespace Tp01_WebServices
{
    public partial class Form1 : Form
    {
        string key = "http://www.omdbapi.com/?apikey=6a44c43e";
        SearchList searchList;
        Movie movie;
        Picture image;
        string titleSearched, typeSearched, yearSearched;
        int totalResults, numPage = 1;

        public Form1()
        {
            InitializeComponent();
        }
        async void GetRequest(string url, bool listSearch)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    using (HttpContent content = response.Content)
                    {
                        string mycontent = await content.ReadAsStringAsync();

                        if(listSearch)
                        {
                            searchList = JsonConvert.DeserializeObject<SearchList>(mycontent);
                            Int32.TryParse(searchList.totalResults, out totalResults);
                            this.listBoxSearchs.Items.Clear();
                            foreach (Search search in searchList.Search)
                            {
                                this.listBoxSearchs.Items.Add(search.Title);
                            }
                            this.textNumPages.Text = "Page: " + numPage + "/" + (totalResults / 10);
                        }
                        else
                        {
                            movie = JsonConvert.DeserializeObject<Movie>(mycontent);
                            this.textBoxDetails.Text = movie.Message();
                            this.linkWeb.Text = movie.Website;
                            this.linkImdb.Text = "https://www.imdb.com/title/" + movie.imdbID + "/?ref_=tt_rec_tti";
                            WebRequest request = WebRequest.Create(movie.Poster);
                            using (var res = request.GetResponse())
                            {
                                using (var str = res.GetResponseStream())
                                {
                                    pictureBoxMovie.Image = Bitmap.FromStream(str);
                                }
                            }

                            string urlPicture = WebUtility.UrlEncode(movie.Poster);
                            GetRequest("https://www.pida.io/data/" + urlPicture + "?format=json");
                        }
                    }
                }
            }
        }
        async void GetRequest(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    using (HttpContent content = response.Content)
                    {
                        string mycontent = await content.ReadAsStringAsync();

                        image = JsonConvert.DeserializeObject<Picture>(mycontent);    
                        this.textTamanioImagen.Text = "Tamanio de Imagen: " + image.ImageSize;
                    }
                }
            }
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            titleSearched = typeSearched = yearSearched = "";

            if ((string)comboBoxType.Items[comboBoxType.SelectedIndex] == "All")
            {
                titleSearched = this.textBoxTitle.Text;
                yearSearched = this.textBoxYear.Text;

                GetRequest(key + "&s=" + this.textBoxTitle.Text + "&y=" + this.textBoxYear.Text, true);
            }
            else if (this.textBoxYear.Text == "")
            {
                titleSearched = this.textBoxTitle.Text;
                typeSearched = (string)comboBoxType.Items[comboBoxType.SelectedIndex];

                GetRequest(key + "&s=" + this.textBoxTitle.Text + "&type=" + (string)comboBoxType.Items[comboBoxType.SelectedIndex], true);
            }
            else if ((string)comboBoxType.Items[comboBoxType.SelectedIndex] == "All" && this.textBoxYear.Text == "")
            {
                titleSearched = this.textBoxTitle.Text;

                GetRequest(key + "&s=" + this.textBoxTitle.Text, true);
            }
            else
            {
                titleSearched = this.textBoxTitle.Text;
                typeSearched = (string)comboBoxType.Items[comboBoxType.SelectedIndex];
                yearSearched = this.textBoxYear.Text;

                GetRequest(key + "&s=" + this.textBoxTitle.Text + "&type=" + (string)comboBoxType.Items[comboBoxType.SelectedIndex] + "&y=" + this.textBoxYear.Text, true);
            }
        }

        private void listBoxSearchs_SelectedIndexChanged(object sender, EventArgs e)
        {
            string plot = "";
            if (checkBoxPlot.Checked)
                plot = "full";
            else
                plot = "short";

            string title = (string)listBoxSearchs.Items[listBoxSearchs.SelectedIndex];
            GetRequest(key + "&t=" + title + "&plot=" + plot, false);
        }

        private void linkWeb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkWeb.LinkVisited = true;
            System.Diagnostics.Process.Start("IExplore.exe", linkWeb.Text);
        }

        private void linkImdb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkImdb.LinkVisited = true;
            System.Diagnostics.Process.Start("IExplore.exe", linkImdb.Text);
        }

        private void checkBoxPlot_CheckedChanged(object sender, EventArgs e)
        {
            if(this.textBoxDetails.Text != "")
            {
                string plot = "";
                if (checkBoxPlot.Checked)
                    plot = "full";
                else
                    plot = "short";

                string title = (string)listBoxSearchs.Items[listBoxSearchs.SelectedIndex];
                GetRequest(key + "&t=" + title + "&plot=" + plot, false);

            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if(numPage < totalResults/10)
            {
                numPage++;

                if (typeSearched == "")
                {
                    GetRequest(key + "&s=" + titleSearched + "&y=" + yearSearched + "&page=" + numPage, true);
                }
                else if (yearSearched == "")
                {
                    GetRequest(key + "&s=" + titleSearched + "&type=" + typeSearched + "&page=" + numPage, true);
                }
                else if (typeSearched == "" && yearSearched == "")
                {
                    GetRequest(key + "&s=" + titleSearched + "&page=" + numPage, true);
                }
                else
                {
                    GetRequest(key + "&s=" + titleSearched + "&type=" + typeSearched + "&y=" + yearSearched + "&page=" + numPage, true);
                }
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (numPage > 1)
            {
                numPage--;

                if (typeSearched == "")
                {
                    GetRequest(key + "&s=" + titleSearched + "&y=" + yearSearched + "&page=" + numPage, true);
                }
                else if (yearSearched == "")
                {
                    GetRequest(key + "&s=" + titleSearched + "&type=" + typeSearched + "&page=" + numPage, true);
                }
                else if (typeSearched == "" && yearSearched == "")
                {
                    GetRequest(key + "&s=" + titleSearched + "&page=" + numPage, true);
                }
                else
                {
                    GetRequest(key + "&s=" + titleSearched + "&type=" + typeSearched + "&y=" + yearSearched + "&page=" + numPage, true);
                }
            }
        }
    }
}
