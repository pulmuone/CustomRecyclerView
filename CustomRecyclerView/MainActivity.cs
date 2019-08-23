using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace CustomRecyclerView
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private RecyclerView recyclerView;
        private CustomAdapter customAdapter;

        List<TableItem> tableItems = new List<TableItem>();

        Button button;
        Button button2;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.HomeScreen);

            recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            button = FindViewById<Button>(Resource.Id.button1);
            button2 = FindViewById<Button>(Resource.Id.button2);

            tableItems.Add(new TableItem() { BarcodeLabel = "8809123456781", ProdName = "신라면", OrderQty = "1", ExpirationDate="2019-08-22" });
            tableItems.Add(new TableItem() { BarcodeLabel = "8809123456782", ProdName = "코카콜라", OrderQty = "2", ExpirationDate = "2019-08-22" });
            tableItems.Add(new TableItem() { BarcodeLabel = "8809123456783", ProdName = "풀무원 두부", OrderQty = "3", ExpirationDate = "2019-08-22" });
            tableItems.Add(new TableItem() { BarcodeLabel = "8809123456784", ProdName = "대상 두부", OrderQty = "4", ExpirationDate = "2019-08-22" });
            tableItems.Add(new TableItem() { BarcodeLabel = "8809123456785", ProdName = "CJ부두", OrderQty = "5", ExpirationDate = "2019-08-22" });
            tableItems.Add(new TableItem() { BarcodeLabel = "8809123456786", ProdName = "스타벅스 커피", OrderQty = "6", ExpirationDate = "2019-08-22" });
            tableItems.Add(new TableItem() { BarcodeLabel = "8809123456787", ProdName = "사이다", OrderQty = "7", ExpirationDate = "2019-08-22" });
            tableItems.Add(new TableItem() { BarcodeLabel = "8809123456788", ProdName = "풀무원 녹즙", OrderQty = "8", ExpirationDate = "2019-08-22" });
            tableItems.Add(new TableItem() { BarcodeLabel = "8809123456789", ProdName = "아이스크림", OrderQty = "9", ExpirationDate = "2019-08-22" });
            tableItems.Add(new TableItem() { BarcodeLabel = "8809123456790", ProdName = "식초", OrderQty = "10", ExpirationDate = "2019-08-22" });
            tableItems.Add(new TableItem() { BarcodeLabel = "8809123456791", ProdName = "우유", OrderQty = "11", ExpirationDate = "2019-08-22" });
            tableItems.Add(new TableItem() { BarcodeLabel = "8809123456792", ProdName = "바나나", OrderQty = "12", ExpirationDate = "2019-08-22" });
            tableItems.Add(new TableItem() { BarcodeLabel = "8809123456793", ProdName = "사과", OrderQty = "13", ExpirationDate = "2019-08-22" });
            tableItems.Add(new TableItem() { BarcodeLabel = "8809123456794", ProdName = "고구마", OrderQty = "14", ExpirationDate = "2019-08-22" });
            tableItems.Add(new TableItem() { BarcodeLabel = "8809123456795", ProdName = "감자", OrderQty = "15", ExpirationDate = "2019-08-22" });
            tableItems.Add(new TableItem() { BarcodeLabel = "8809123456796", ProdName = "녹차", OrderQty = "16", ExpirationDate = "2019-08-22" });
            tableItems.Add(new TableItem() { BarcodeLabel = "8809123456797", ProdName = "홍초", OrderQty = "17", ExpirationDate = "2019-08-22" });

            customAdapter = new CustomAdapter(tableItems);

            recyclerView.SetLayoutManager(new LinearLayoutManager(this.ApplicationContext));

            recyclerView.SetAdapter(customAdapter);

            button.Click += Button_Click;
            button2.Click += Button2_Click;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            recyclerView.ScrollToPosition(1);
            (customAdapter.holder as MyViewHolder).OnClick2(1);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            recyclerView.ScrollToPosition(13);
            (customAdapter.holder as MyViewHolder).OnClick2(13);
        }
    }
}

