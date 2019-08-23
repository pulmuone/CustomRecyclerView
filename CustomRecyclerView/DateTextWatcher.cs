using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace CustomRecyclerView
{
    public class DateTextWatcher : Java.Lang.Object, ITextWatcher
    {
        List<TableItem> items;
        MyViewHolder myViewHolder;
        string Mask = "XXXX-XX-XX";
        IDictionary<int, char> _positions;

        public DateTextWatcher(MyViewHolder holder, List<TableItem> data )
        {
            myViewHolder = holder;
            items = data;

            SetPositions();
        }

        /// <summary>
        /// 3
        /// </summary>
        /// <param name="s"></param>
        public void AfterTextChanged(IEditable s)
        {
            if (s != null && !"".Equals(s.ToString()))
            {
                var text = s.ToString().Trim();

                if (string.IsNullOrWhiteSpace(text) || _positions == null)
                    return;

                if (text.Length > Mask.Length)
                {
                    items[myViewHolder.AdapterPosition].ExpirationDate = text.Remove(text.Length - 1);
                    return;
                }

                foreach (var position in _positions)
                {
                    if (text.Length >= position.Key + 1)
                    {
                        var value = position.Value.ToString();
                        if (text.Substring(position.Key, 1) != value)
                        {
                            text = text.Insert(position.Key, value);
                        }
                    }
                }

                if (items[myViewHolder.AdapterPosition].ExpirationDate != text)
                {
                    items[myViewHolder.AdapterPosition].ExpirationDate = text;
                }

                Regex LongDate = new Regex(@"[0-9]{4}-[0-9]{2}-[0-9]{2}");
                DateTime result;
                bool isValid = false;

                if (LongDate.Match(text.ToString().Trim()).Success)
                {
                    Console.WriteLine("Date Regex Success");
                    isValid = DateTime.TryParse(text.ToString().Trim(), out result);
                    if (isValid)
                    {
                        Console.WriteLine("Date DateValidation Success");
                        Console.WriteLine(result.ToString());
                    }
                    else
                    {
                        Console.WriteLine("Date DateValidation Fail");
                    }
                }
                else
                {
                    //Debug.WriteLine("Date Regex Fail");
                }

                myViewHolder.ExpirationDate.SetBackgroundColor(isValid ? Color.White : Color.Red);

            }
        }

        /// <summary>
        /// 1
        /// </summary>
        /// <param name="s"></param>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <param name="after"></param>
        public void BeforeTextChanged(ICharSequence s, int start, int count, int after)
        {

        }

        /// <summary>
        /// 2
        /// </summary>
        /// <param name="s"></param>
        /// <param name="start"></param>
        /// <param name="before"></param>
        /// <param name="count"></param>
        public void OnTextChanged(ICharSequence s, int start, int before, int count)
        {
            
            //items[myViewHolder.AdapterPosition].ExpirationDate.SetBackgroundColor(isValid ? Color.White : Color.Red);
        }

        void SetPositions()
        {
            if (string.IsNullOrEmpty(Mask))
            {
                _positions = null;
                return;
            }

            var list = new Dictionary<int, char>();
            for (var i = 0; i < Mask.Length; i++)
                if (Mask[i] != 'X')
                    list.Add(i, Mask[i]);

            _positions = list;
        }
    }
}