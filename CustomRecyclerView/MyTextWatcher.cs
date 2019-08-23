using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace CustomRecyclerView
{
    public class MyTextWatcher : Java.Lang.Object, ITextWatcher
    {
        List<TableItem> items;
        MyViewHolder myViewHolder;

        public MyTextWatcher(MyViewHolder holder, List<TableItem> data)
        {
            myViewHolder = holder;
            items = data;
        }

        public void AfterTextChanged(IEditable s)
        {
            if (s != null && !"".Equals(s.ToString()))
            {
                items[myViewHolder.AdapterPosition].OrderQty = s.ToString();
            }
        }

        public void BeforeTextChanged(ICharSequence s, int start, int count, int after)
        {
            
        }

        public void OnTextChanged(ICharSequence s, int start, int before, int count)
        {

        }
    }
}