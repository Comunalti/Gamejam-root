using System;
using KevinCastejon.MoreAttributes;
using Slots.Connector;
using UnityEngine;
using UnityEngine.Events;

namespace Slots
{
    public class PlantSlot : MonoBehaviour
    {
        
    }

    public class Plant : MonoBehaviour
    {
        
    }

    namespace MouseInteraction
    {
    }
    
    
    namespace TriggerHandler
    {
        public class PlantSlotTriggerHandler : MonoBehaviour
        {
            [ReadOnlyOnPlay] [SerializeField] private PlantSlotConnector plantSlotConnector;
        }
        public class PlantTriggerHandler : MonoBehaviour
        {
            [ReadOnlyOnPlay] [SerializeField] private PlantConnector plantConnector;
        }
    }
    namespace Connector
    {
        

        public class PlantSlotConnector : MonoBehaviour
        {
            [field: ReadOnlyOnPlay]
            [field: SerializeField]
            public PlantSlot PlantSlot { get; private set; }

            [ReadOnly][SerializeField] private PlantConnector currentPlantConnector;

            public UnityEvent onCurrentPlantChangedEvent;

            public void SetPlant(PlantConnector plantConnector)
            {

            }
        }

        public class PlantConnector : MonoBehaviour
        {
            [field: ReadOnlyOnPlay]
            [field: SerializeField]
            public Plant Plant { get; private set; }


            [ReadOnly][SerializeField] private PlantSlotConnector currentPlantSlotConnector;

            public UnityEvent onCurrentPlantSlotChangedEvent;

            public void SetPlantSlot(PlantSlotConnector plantSlotConnector)
            {

            }
        }
    }
}