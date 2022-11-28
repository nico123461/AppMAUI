using AppMAUI.Services;
using Service.Model;
using Service.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AppMAUI.ModelView
{
    public class MainPageModelView : AbstractModelView
    {
        private IDisplayMessage displayMessage;
        private IWebService webService;
        private List<Employee> employees_list;
        private ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        private bool isRefreshing;
        private Employee employee;
        private string searchText;

        /// <summary>
        /// Variable que determina si se muestra o no un mensaje de error
        /// </summary>
        private bool isShowMessageErrorLoad = false;
        

        #region Properties

        public ObservableCollection<Employee> Employees
        {
            get
            {
                if (employees.Count == 0)
                {
                    IsRefreshing = true;
                }
                return employees;
            }
        }

        public bool IsRefreshing
        {
            get => isRefreshing;
            set => SetProperty(ref isRefreshing, value);
        }

        public Employee EmployeeSelected
        {
            get => employee;
            set
            {
                SetProperty(ref employee, value);
                if (value != null)
                {
                    OnSelecteEmploye();
                }
            }
        }

        public string SearchText 
        { 
            get => searchText;
            set 
            { 
                SetProperty(ref searchText, value);
                if(searchText == "")
                {
                    FilterList();
                }
            } 
        }

        public ICommand RefreshCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public ICommand SearchCommand { get; set; }

        #endregion

        public MainPageModelView(IDisplayMessage displayMessage, IWebService webService) : base(displayMessage)
        {
            this.displayMessage = displayMessage;
            this.webService = webService;
            this.onLogoutAction = OnLogoutApplication;
            RefreshCommand = new Command(() => LoadItems());
            CancelCommand = new Command(() => OnCancelButton());
            SearchCommand = new Command(() => FilterList());
        }

        #region Private
        /// <summary>
        /// Carga el listado de empleados
        /// </summary>
        private async void LoadItems()
        {
            try
            {
                isShowMessageErrorLoad = true;
                EmployeeSelected = null;
                employees.Clear();
                employees_list = await webService.GetAllEmployees();
                SearchText = "";
            }
            catch (Exception ex)
            {
                if (isShowMessageErrorLoad)
                    await displayMessage.ShowDisplayMessage_KeyString("Error", "ErrorLoadingEmployee");
            }
            finally
            {
                IsRefreshing = false;
            }
        }

        /// <summary>
        /// Al seleccionar un empleado
        /// </summary>
        private void OnSelecteEmploye()
        {
            var navigationParameters = new Dictionary<string, object>
            {
                {"employe",  employee}
            };
            Shell.Current.GoToAsync("EmployeDetail", navigationParameters);
            EmployeeSelected = null;
        }

        /// <summary>
        /// Cuando el usuario le da al boton salir
        /// </summary>
        private void OnLogoutApplication()
        {
            isShowMessageErrorLoad = false;
            webService.StopTask();
        }

        /// <summary>
        /// Si se está realizando una busqueda y el usuario la quiere cancelar
        /// </summary>
        private async void OnCancelButton()
        {
            isShowMessageErrorLoad = false;
            webService.StopTask();
            await displayMessage.ShowDisplayMessage_KeyString("Error", "StopSearchByUser");
        }

        /// <summary>
        /// Cuando se filtra el listado de empleados
        /// </summary>
        private void FilterList()
        {
            employees.Clear();
            if (!string.IsNullOrEmpty(SearchText))
            {
                employees_list.Where(x => x.Username.ToLower().Contains(SearchText.ToLower()) || x.Email.ToLower().Contains(SearchText.ToLower()))
                    .ToList().ForEach(x => { employees.Add(x); });
            }
            else
            {
                foreach (var item in employees_list)
                    employees.Add(item);
            }
        }
        #endregion

    }
}
