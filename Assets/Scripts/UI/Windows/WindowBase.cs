using UnityEngine;

namespace UI.Windows
{
    public abstract class WindowBase : MonoBehaviour
    {
        public WindowType Id { get; protected set; }
        
        public void SetId(WindowType id) => Id = id;
    }
}