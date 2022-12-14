using session1_framework.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace session1_framework
{
    /// <summary>
    /// Interaction logic for SelectPage.xaml
    /// </summary>
    public partial class SelectPage : Page
    {
        int currentPage = 1;
        int totalPages = 0;
        List<Agent> currentList = null;
        List<String> agentType = null;
        int order = 0;
        public SelectPage()
        {
            InitializeComponent();
            currentList =  getAgentList();
            agentType = getAgentTypeList();
            updateAgentTypeFilter();
            updateList();
            

        }
        

        public List<Agent> getAgentList()
        {
            var list = session1Entities.getContext().Agent.ToList();
            return list;
        }
        public List<String> getAgentTypeList()
        {
            List<AgentType> typeList = session1Entities.getContext().AgentType.ToList();
            List<String> agentTypes = new List<String>();
            foreach (AgentType agentType in typeList)
            {
                agentTypes.Add( agentType.Title);
            }
            return agentTypes;
        }

        public void changeOrder(int _order)
        {
            order = _order;
            updateList();
        }
        public void updateAgentTypeFilter()
        {
            boxFilter.Items.Clear();
            agentType.Insert(0, "Все типы");
           
            foreach (var item in agentType)
            {
                boxFilter.Items.Add(item);
            }
            boxFilter.SelectedIndex = 0;

        }
        public void updateList()
        {
           
            currentList = getAgentList();
            if (boxFilter.SelectedValue as String != "Все типы") 
            {
                currentList = (currentList.Where(item => item.AgentType.Title == (boxFilter.SelectedValue as String))).ToList();
            }
            
            //searchBar.Text = boxFilter.SelectedValue as String;
            if (order == 2)
            {
                currentList = currentList.OrderByDescending(i => i.Title).ToList();
            }
            else if(order ==1)
            {
                currentList = currentList.OrderBy(i => i.Title).ToList();
            }
            if (searchBar.Text != "")
            {
                currentList =  currentList.Where(i => i.Title.ToLower().Contains(searchBar.Text.ToLower())).ToList();

            }
            totalPages = (int) Math.Ceiling(currentList.Count / 10.0);
            currentList = currentList.Where((x, index) => {
                if (index < currentPage * 10 && index > (currentPage - 1) * 10)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }).ToList();
            
            listView.ItemsSource = currentList;
            List<Button> pages = new List<Button>();
            for (int i = 1; i <= totalPages; i++)
            {
                Button b = new Button();
                TextBlock t = new TextBlock();
                t.Text = i.ToString();
                b.Content = t;
                b.Click += buttonToPageClicked;
                b.Name = "buttonPage" + i.ToString();
                b.MinWidth =20;
                Style style = new Style(typeof(Button));
                style.Setters.Add(new Setter(Button.BorderThicknessProperty, new Thickness(0)));
                style.Setters.Add(new Setter(Button.BackgroundProperty, Brushes.Transparent));
                b.Style = style;
                pages.Add(b);
            }
            Button currentBtn = pages.Where(i => (i.Content as TextBlock).Text.Equals(currentPage.ToString())).FirstOrDefault();
            if (currentBtn != null)
            {
                TextBlock t = new TextBlock();
                t.Text = (currentBtn.Content as TextBlock).Text;
                t.TextDecorations = TextDecorations.Underline;
                currentBtn.Content = t;

            }
            pageCounter.ItemsSource = pages;
            List<Button> pageCounterList =  pageCounter.Items.Cast<Button>().ToList();
            
            
        }

        private void buttonToPageClicked(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int toPage = int.Parse((button.Content as TextBlock).Text);
            currentPage =  toPage;
            updateList();
        }

        public void pageAdd()
        {
            if (currentPage < totalPages)
                currentPage++;
            updateList();
        }
        public void pageBack()
        {
            if (currentPage > 1)
                currentPage--;
            updateList();
        }



        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            pageBack();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            pageAdd();  
        }

        private void boxSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            order = boxSort.SelectedIndex;
            if (this.IsLoaded) {
                updateList();
            } 
        }

        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            updateList();
        }

        private void boxFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (currentList!=null)
            {
                currentPage = 1;
                updateList();
            }
            

        }
    }
}
