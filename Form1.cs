using System.Text.RegularExpressions;

namespace 星空计算器
{
    public partial class Formmain : Form
    {
        public Formmain()
        {
            InitializeComponent();
        }

        private void buttonclear1_Click(object sender, EventArgs e)
        {
            textBoxfl.Text = textBoxaper.Text = textBoxdiam1.Text = textBoxlims.Text = textBoxliml.Text = "";
            textBoxwaves.Text = "400";
            textBoxwavel.Text = "700";
            textBoxfl.Focus();
        }

        private void buttoncal1_Click(object sender, EventArgs e)
        {
            float.TryParse(textBoxfl.Text, out float fl);
            float.TryParse(textBoxaper.Text, out float aper);
            float.TryParse(textBoxdiam1.Text, out float diam1);
            float.TryParse(textBoxwaves.Text, out float waves);
            float.TryParse(textBoxwavel.Text, out float wavel);
            if (waves > 0 && wavel > 0 && wavel > waves)
            {
                if (fl > 0 && aper > 0 && diam1 == 0)
                {
                    diam1 = fl / aper;
                    float lims = (float)(Math.Asin(1.22 * waves / (diam1 * 1000000)) * 648000 / Math.PI);
                    float liml = (float)(Math.Asin(1.22 * wavel / (diam1 * 1000000)) * 648000 / Math.PI);
                    textBoxdiam1.Text = diam1.ToString("F2");
                    textBoxlims.Text = lims.ToString("F2");
                    textBoxliml.Text = liml.ToString("F2");
                }
                else if (fl > 0 && diam1 > 0 && aper == 0)
                {
                    aper = fl / diam1;
                    float lims = (float)(Math.Asin(1.22 * waves / (diam1 * 1000000)) * 648000 / Math.PI);
                    float liml = (float)(Math.Asin(1.22 * wavel / (diam1 * 1000000)) * 648000 / Math.PI);
                    textBoxaper.Text = aper.ToString("F2");
                    textBoxlims.Text = lims.ToString("F2");
                    textBoxliml.Text = liml.ToString("F2");
                }
                else if (aper > 0 && diam1 > 0 && fl == 0)
                {
                    fl = aper * diam1;
                    float lims = (float)(Math.Asin(1.22 * waves / (diam1 * 1000000)) * 648000 / Math.PI);
                    float liml = (float)(Math.Asin(1.22 * wavel / (diam1 * 1000000)) * 648000 / Math.PI);
                    textBoxfl.Text = fl.ToString("F2");
                    textBoxlims.Text = lims.ToString("F2");
                    textBoxliml.Text = liml.ToString("F2");
                }
                else if (diam1 > 0)
                {
                    float lims = (float)(Math.Asin(1.22 * waves / (diam1 * 1000000)) * 648000 / Math.PI);
                    float liml = (float)(Math.Asin(1.22 * wavel / (diam1 * 1000000)) * 648000 / Math.PI);
                    textBoxlims.Text = lims.ToString("F2");
                    textBoxliml.Text = liml.ToString("F2");
                }
                else
                {
                    textBoxlims.Text = textBoxliml.Text = "输入有误";
                }
            }
            else
            {
                textBoxlims.Text = textBoxliml.Text = "输入有误";
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetDataObject("https://github.com/GarthTB/astrophoto-calculator");
            MessageBox.Show("源码链接已复制到剪贴板。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void comboBoxmodel_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxmodel.SelectedItem.ToString())
            {
                case "":
                    textBoxsensorh.Text = textBoxsensorv.Text = textBoxsensorhn.Text = textBoxsensorvn.Text = textBoxpixelh.Text = textBoxpixelv.Text = "";
                    break;
                case "Z6 (IMX410)":
                case "α7Ⅲ (IMX410)":
                    textBoxsensorh.Text = "36.07";
                    textBoxsensorv.Text = "24.01";
                    textBoxsensorhn.Text = "6072";
                    textBoxsensorvn.Text = "4042";
                    textBoxpixelh.Text = textBoxpixelv.Text = "5.94";
                    break;
                case "D5100 (IMX071)":
                    textBoxsensorh.Text = "23.73";
                    textBoxsensorv.Text = "15.76";
                    textBoxsensorhn.Text = "4944";
                    textBoxsensorvn.Text = "3284";
                    textBoxpixelh.Text = textBoxpixelv.Text = "4.80";
                    break;
            }
        }

        private void buttonclear2_Click(object sender, EventArgs e)
        {
            comboBoxmodel.SelectedItem = "";
            textBoxsensorh.Text = textBoxsensorv.Text = textBoxsensorhn.Text = textBoxsensorvn.Text = textBoxpixelh.Text = textBoxpixelv.Text = textBoxangleh1.Text = textBoxanglev1.Text = "";
            comboBoxmodel.Focus();
        }

        private void buttoncal2_Click(object sender, EventArgs e)
        {
            float.TryParse(textBoxfl.Text, out float fl);
            float.TryParse(textBoxsensorh.Text, out float sensorh);
            float.TryParse(textBoxsensorv.Text, out float sensorv);
            int.TryParse(textBoxsensorhn.Text, out int sensorhn);
            int.TryParse(textBoxsensorvn.Text, out int sensorvn);
            if (sensorh > 0 && sensorhn > 0)
            {
                float pixelh = sensorh * 1000 / sensorhn;
                textBoxpixelh.Text = pixelh.ToString("F2");
            }
            else
            {
                textBoxpixelh.Text = "输入有误";
            }
            if (sensorv > 0 && sensorvn > 0)
            {
                float pixelv = sensorv * 1000 / sensorvn;
                textBoxpixelv.Text = pixelv.ToString("F2");
            }
            else
            {
                textBoxpixelv.Text = "输入有误";
            }
            if (fl > 0 && sensorh > 0)
            {
                float arcminh;
                float angleh1 = (float)(Math.Atan(sensorh / fl) * 180 / Math.PI);
                if (angleh1 >= 1)
                {
                    arcminh = angleh1 % 1 * 60;
                    angleh1 = angleh1 - angleh1 % 1;
                    textBoxangleh1.Text = angleh1.ToString("F0") + "°" + arcminh.ToString("F2") + "′";
                }
                else
                {
                    arcminh = angleh1 % 1 * 60;
                    textBoxangleh1.Text = arcminh.ToString("F2") + "′";
                }
            }
            else
            {
                textBoxangleh1.Text = "输入有误";
            }
            if (fl > 0 && sensorv > 0)
            {
                float arcminv;
                float anglev1 = (float)(Math.Atan(sensorv / fl) * 180 / Math.PI);
                if (anglev1 >= 1)
                {
                    arcminv = anglev1 % 1 * 60;
                    anglev1 = anglev1 - anglev1 % 1;
                    textBoxanglev1.Text = anglev1.ToString("F0") + "°" + arcminv.ToString("F2") + "′";
                }
                else
                {
                    arcminv = anglev1 % 1 * 60;
                    textBoxanglev1.Text = arcminv.ToString("F2") + "′";
                }
            }
            else
            {
                textBoxanglev1.Text = "输入有误";
            }
        }

        private void buttonclear3_Click(object sender, EventArgs e)
        {
            textBoxres1.Text = textBoxdec.Text = textBoxfwhm.Text = textBoxexp1.Text = "";
            buttoncal31.Focus();
        }

        private void buttoncal31_Click(object sender, EventArgs e)
        {
            float.TryParse(textBoxfl.Text, out float fl);
            float.TryParse(textBoxpixelh.Text, out float pixelh);
            float.TryParse(textBoxpixelv.Text, out float pixelv);
            if (fl > 0)
            {
                if (pixelh > 0 && pixelv > 0)
                {
                    float res1 = (float)(Math.Atan((pixelh + pixelv) / fl / 2000) * 648000 / Math.PI);
                    textBoxres1.Text = res1.ToString("F2");
                }
                else if (pixelh > 0 || pixelv > 0)
                {
                    float res1 = (float)(Math.Atan((pixelh + pixelv) / fl / 1000) * 648000 / Math.PI);
                    textBoxres1.Text = res1.ToString("F2");
                }
                else
                {
                    textBoxres1.Text = "输入有误";
                }
            }
            else
            {
                textBoxres1.Text = "输入有误";
            }
        }

        private void buttoncal32_Click(object sender, EventArgs e)
        {
            float.TryParse(textBoxres1.Text, out float res1);
            float.TryParse(textBoxdec.Text, out float dec);
            float.TryParse(textBoxfwhm.Text, out float fwhm);
            float.TryParse(textBoxexp1.Text, out float exp1);
            if (res1 > 0 && dec >= -90 && dec <= 90)
            {
                if (fwhm > 0 && exp1 >= 0)
                {
                    exp1 = (float)(res1 * fwhm * 21541 / Math.Cos(dec * Math.PI / 180) / 324000);
                    textBoxexp1.Text = exp1.ToString("N3");
                }
                else if (exp1 > 0 && fwhm == 0)
                {
                    fwhm = (float)(Math.Cos(dec * Math.PI / 180) * 324000 * exp1 / res1 / 21541);
                    textBoxexp1.Text = fwhm.ToString("N3");
                }
                else
                {
                    textBoxexp1.Text = "输入有误";
                }
            }
            else
            {
                textBoxexp1.Text = "输入有误";
            }
        }

        private void buttonclear4_Click(object sender, EventArgs e)
        {
            comboBoxunit.SelectedItem = "";
            textBoxres2.Text = textBoxtardiam.Text = textBoxsize.Text = "";
            buttoncal41.Focus();
        }

        private void buttoncal41_Click(object sender, EventArgs e)
        {
            float.TryParse(textBoxfl.Text, out float fl);
            float.TryParse(textBoxpixelh.Text, out float pixelh);
            float.TryParse(textBoxpixelv.Text, out float pixelv);
            if (fl > 0)
            {
                if (pixelh > 0 && pixelv > 0)
                {
                    float res1 = (float)(Math.Atan((pixelh + pixelv) / fl / 2000) * 648000 / Math.PI);
                    textBoxres2.Text = res1.ToString("F2");
                }
                else if (pixelh > 0 || pixelv > 0)
                {
                    float res1 = (float)(Math.Atan((pixelh + pixelv) / fl / 1000) * 648000 / Math.PI);
                    textBoxres2.Text = res1.ToString("F2");
                }
                else
                {
                    textBoxres2.Text = "输入有误";
                }
            }
            else
            {
                textBoxres2.Text = "输入有误";
            }
        }

        private void buttoncal42_Click(object sender, EventArgs e)
        {
            float.TryParse(textBoxres2.Text, out float res2);
            float.TryParse(textBoxtardiam.Text, out float tardiam);
            if (res2 > 0 && tardiam > 0 && comboBoxunit.SelectedItem.ToString() != "")
            {
                float size;
                switch (comboBoxunit.SelectedItem.ToString())
                {
                    case "度":
                        size = tardiam * 3600 / res2;
                        textBoxsize.Text = size.ToString("F3");
                        break;
                    case "分":
                        size = tardiam * 60 / res2;
                        textBoxsize.Text = size.ToString("F3");
                        break;
                    case "秒":
                        size = tardiam / res2;
                        textBoxsize.Text = size.ToString("F3");
                        break;
                }
            }
            else
            {
                textBoxsize.Text = "输入有误";
            }
        }

        private void buttonclear5_Click(object sender, EventArgs e)
        {
            textBoxangleh2.Text = textBoxanglev2.Text = textBoxres3.Text = textBoxdiam2.Text = textBoxexp2.Text = textBoxeff.Text = "";
            textBoxangleh2.Focus();
        }

        private void buttoncal5_Click(object sender, EventArgs e)
        {
            string angleh2s = textBoxangleh2.Text;
            string anglev2s = textBoxanglev2.Text;
            float.TryParse(textBoxres3.Text, out float res3);
            float.TryParse(textBoxdiam2.Text, out float diam2);
            float.TryParse(textBoxexp2.Text, out float exp2);
            if (string.IsNullOrWhiteSpace(angleh2s) == false && string.IsNullOrWhiteSpace(anglev2s) == false && res3 > 0 && diam2 > 0 && exp2 > 0)
            {
                string RegexStr = @".*°.*′";
                MatchCollection matchCollectionh = Regex.Matches(angleh2s, RegexStr);
                MatchCollection matchCollectionv = Regex.Matches(anglev2s, RegexStr);
                if (matchCollectionh.Count == 1 && matchCollectionv.Count == 1)
                {
                    float angleh2, anglev2;
                    if (angleh2s.Contains('°'))
                    {
                        string[] split = angleh2s.Split(new char[2] { '°', '′' });
                        float.TryParse(split[0], out float degh);
                        float.TryParse(split[1], out float arcminh);
                        angleh2 = degh * 60 + arcminh;
                        if (angleh2 == 0)
                        {
                            textBoxeff.Text = "输入错误";
                            return;
                        }
                    }
                    else
                    {
                        string[] split = angleh2s.Split('′');
                        float.TryParse(split[0], out angleh2);
                        if (angleh2 == 0)
                        {
                            textBoxeff.Text = "输入错误";
                            return;
                        }
                    }
                    if (anglev2s.Contains('°'))
                    {
                        string[] split = anglev2s.Split(new char[2] { '°', '′' });
                        float.TryParse(split[0], out float degv);
                        float.TryParse(split[1], out float arcminv);
                        anglev2 = degv * 60 + arcminv;
                        if (anglev2 == 0)
                        {
                            textBoxeff.Text = "输入错误";
                            return;
                        }
                    }
                    else
                    {
                        string[] split = anglev2s.Split('′');
                        float.TryParse(split[0], out anglev2);
                        if (anglev2 == 0)
                        {
                            textBoxeff.Text = "输入错误";
                            return;
                        }
                    }
                    double eff = angleh2 * anglev2 * Math.Pow(diam2 / 2, 2) * Math.PI * Math.Pow(res3 / 60, 2) * exp2 / 1000;
                    textBoxeff.Text = eff.ToString("F0");
                }
                else
                {
                    textBoxeff.Text = "输入错误";
                }
            }
            else
            {
                textBoxeff.Text = "输入错误";
            }
        }
    }
}