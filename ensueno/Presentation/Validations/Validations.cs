using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ensueno.Presentation.Validations
{
    internal class Validations
    {
        public static bool numbers_only(KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
                return true;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return true;
            }
            else
            {
                e.Handled = true;
                return false;
            }
        }
        public static bool empty_text(Guna2TextBox ptxt)
        {
            if (ptxt.Text == string.Empty)
            {
                ptxt.Focus();
                return true;
            }
            else return false;
        }

        public static bool decimal_only(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
                return true;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return true;
            }
            else if (Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = false;
                return true;
            }
            else
            {
                e.Handled = true;
                return false;
            }
        }

        public static bool Chars_Only(KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
                return true;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return true;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
                return true;
            }
            else
            {
                e.Handled = true;
                return false;
            }
        }
    }
    public class Values
    {
        ErrorProvider error = new ErrorProvider();
        public void empty_text(Guna2TextBox txt)
        {
            if (Validations.empty_text(txt))
                error.SetError(txt, "Este campo no puede estar vacio");
            else
                error.Clear();
        }
        public void number(Guna2TextBox txt, KeyPressEventArgs e)
        {
            bool v = Validations.numbers_only(e);
            if (!v)
                error.SetError(txt, "Solo se Admiten numeros");
            else
                error.Clear();
        }
        public void numbers_only(Guna2TextBox txt, KeyPressEventArgs e)
        {
            bool v = Validations.numbers_only(e);
            if (!v)
                error.SetError(txt, "Solo se Admiten numeros");

            else if (Validations.empty_text(txt))
                error.SetError(txt, "Este campo no puede estar vacio");
            else
                error.Clear();
        }
        public void decimal_only(Guna2TextBox txt, KeyPressEventArgs e)
        {
            bool v = Validations.decimal_only(e);
            if (!v)
                error.SetError(txt, "Solo se Admiten numeros");

            else if (Validations.empty_text(txt))
                error.SetError(txt, "Este campo no puede estar vacio");
            else
                error.Clear();
        }

        public void Char_only(Guna2TextBox txt, KeyPressEventArgs e)  
        {
        bool v = Validations.Chars_Only(e);
            if (!v)
                error.SetError(txt, "Solo se Admiten Letras");
            else if (Validations.empty_text(txt))
                error.SetError(txt, "Este campo no puede estar vacio");
            else
                error.Clear();
        }
        public void Search_by_letters(Guna2TextBox txt,KeyPressEventArgs e)
        {
            bool v = Validations.Chars_Only(e);
            if (!v)
                error.SetError(txt, "Solo se Admiten Letras");
            else
                error.Clear();
        }
    }
}
