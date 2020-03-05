using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snet.Templates
{
    [System.Serializable]
    public class TemplateEntity
    {
        [SerializeField]
        public int Id;
        [SerializeField]
        public bool MainCharacter;
        [SerializeField]
        public bool IsMap;
        [SerializeField]
        public int OwnerId;
        [SerializeField]
        public string Class;
        [SerializeField]
        public string ResourcePath;
        [SerializeField]
        public float MaxHealth;
        [SerializeField]
        public float Health;
        [SerializeField]
        public float[] Position;
        [SerializeField]
        public float[] Rotation;
    }
}