using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Environment
{
    public class VehicleSelector : MonoBehaviour
    {
        [SerializeField] private GameObject _infoPanel;
        [SerializeField] private Text _modelInfo, _ownerInfo;
        [SerializeField] private LayerMask _layer;

        private Camera _camera;

        private GameObject _selectedVehicle;
        public GameObject SelectedVehicle => _selectedVehicle;


        private string[] _driverNames = new string[] { "John", "Micke", "Sara", "Phill", "Miley" };


        private void Awake()
        {
            _camera = Camera.main;
        }

        private void FixedUpdate()
        {
            if(Input.GetMouseButton(0))
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit, 100, _layer))
                {
                    var current = hit.collider.gameObject;

                    if(_selectedVehicle != current)
                    {
                        ShowVehicleInfo(true, current);
                        SetOutlineState(current);

                        _selectedVehicle = current;
                    }
                    
                }
                else
                {
                    ShowVehicleInfo(false);
                    SetOutlineState();
                }
            }
            
        }

        private void ShowVehicleInfo(bool isNeedToShow, GameObject vehicle = null)
        {
            if(isNeedToShow)
            {
                _infoPanel.SetActive(true);

                string model = vehicle.name.Substring(0, vehicle.name.Length - 7); //Example: Veh_Car_Blue(Clone) => Veh_Car_Blue;
                _modelInfo.text = $"Vehicle model: {model}";

                _ownerInfo.text = $"Vehicle owner: {_driverNames[Random.Range(0, _driverNames.Length)]}";

            }
            else
            {
                _infoPanel.SetActive(false);
            }
        }

        private void SetOutlineState(GameObject current = null)
        {
            if (_selectedVehicle != null)
            {
                _selectedVehicle.GetComponent<Outline>().enabled = false;
                _selectedVehicle = null;
            }

            if (current != null)
                current.GetComponent<Outline>().enabled = true;
        }
    }
}