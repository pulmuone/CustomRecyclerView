using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using Android.Text;
using Android.Util;

namespace CustomRecyclerView
{
    public delegate void ItemClickDelegate(View view, int position);
    public class MyViewHolder : RecyclerView.ViewHolder, View.IOnClickListener
    {
        public Button ButtonPlus { get; set; }
        public Button ButtonMinus { get; set; }
        public TextView BarcodeLabel { get; set; }
        public TextView ProdName { get; set; }
        public EditText OrderQty { get; set; }

        public EditText ExpirationDate { get; set; }

        public event ItemClickDelegate OnItemClicked;

        public MyViewHolder(View v) : base(v)
        {
            ButtonPlus = (Button)v.FindViewById(Resource.Id.buttonPlus);
            ButtonMinus = (Button)v.FindViewById(Resource.Id.buttonMinus);
            BarcodeLabel = (TextView)v.FindViewById(Resource.Id.BarcodeLabel);
            ProdName = (TextView)v.FindViewById(Resource.Id.ProdName);
            OrderQty = (EditText)v.FindViewById(Resource.Id.OrderQty);
            ExpirationDate = (EditText)v.FindViewById(Resource.Id.ExpirationDate);

            v.SetOnClickListener(this);
        }

        public void OnClick(View v)
        {
            this.OnItemClicked?.Invoke(v, this.AdapterPosition);
        }

        public void OnClick2(int rowIndex)
        {
            this.OnItemClicked?.Invoke(this.ItemView, rowIndex);
        }
    }
}