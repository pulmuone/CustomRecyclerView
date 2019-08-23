using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using static Android.Support.V7.Widget.RecyclerView;

namespace CustomRecyclerView
{
    public class CustomAdapter : RecyclerView.Adapter
    {
        List<TableItem> _tableItems = new List<TableItem>();
        public RecyclerView.ViewHolder holder;

        public  int row_index = -1;

        public CustomAdapter(List<TableItem> tableItems)
        {
            _tableItems = tableItems;
        }
        public override int ItemCount => _tableItems.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            this.holder = holder;
            //(holder as MyViewHolder).BarcodeLabel.SetText(_tableItems[position].BarcodeLabel, EditText.BufferType.Normal);
            //(holder as MyViewHolder).ProdName.SetText(_tableItems[position].ProdName, EditText.BufferType.Normal);
            //(holder as MyViewHolder).OrderQty.SetText(_tableItems[position].OrderQty, EditText.BufferType.Editable); //Textview를 EditView로 Cast할 때 사용함.

            (holder as MyViewHolder).BarcodeLabel.Text = _tableItems[position].BarcodeLabel;
            (holder as MyViewHolder).ProdName.Text = _tableItems[position].ProdName;
            (holder as MyViewHolder).OrderQty.Text = _tableItems[position].OrderQty;
            (holder as MyViewHolder).ExpirationDate.Text = _tableItems[position].ExpirationDate;

            (holder as MyViewHolder).OnItemClicked += CustomAdapter_OnItemClicked;

            if(row_index == position)
            {
                holder.ItemView.SetBackgroundColor(Color.Yellow);
            }
            else
            {
                holder.ItemView.SetBackgroundColor(Color.White);
            }                        
        }

        public void CustomAdapter_OnItemClicked(View view, int position)
        {
            row_index = position;
            //Common.currentItem = _tableItems[position];
            this.NotifyDataSetChanged();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View v = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.CustomView, parent, false);

            MyViewHolder vh = new MyViewHolder(v);

             vh.ButtonPlus.Click += (object sender, EventArgs e) =>
            {
                vh.OrderQty.Text = (Convert.ToInt32(vh.OrderQty.Text.Trim()) + 1).ToString();
            };

            vh.ButtonMinus.Click += (object sender, EventArgs e) =>
            {
                vh.OrderQty.Text = (Convert.ToInt32(vh.OrderQty.Text.Trim()) - 1) <= 0 ? "0" : (Convert.ToInt32(vh.OrderQty.Text.Trim()) - 1).ToString();
            };

            vh.OrderQty.AddTextChangedListener(new MyTextWatcher(vh, _tableItems));

            vh.ExpirationDate.AddTextChangedListener(new DateTextWatcher(vh, _tableItems));

            return vh;
        }
    }
}