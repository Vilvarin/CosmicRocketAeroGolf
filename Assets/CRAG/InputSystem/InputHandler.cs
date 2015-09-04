using UnityEngine;
using System.Collections.Generic;

namespace CRAG.InputSystem
{
    public class InputHandler : MonoBehaviour
    {
        public GameActor player;
        public Camera cam;

        public static InputHandler instance;

        private List<ICommand> _onCommands = new List<ICommand>();

        void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);
        }

        public void AddCommand(ICommand command)
        {
            _onCommands.Add(command);
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
                _onCommands.Add(new ImpulseCommand());
            if (Input.GetMouseButton(1))
                _onCommands.Add(new EnterCommand());
            if (Input.GetMouseButtonUp(1))
                _onCommands.Add(new DescendCommand());
        }

        void FixedUpdate()
        {
            foreach (ICommand command in _onCommands)
            {
                command.Execute(player);
            }

            _onCommands.Clear();
        }
    }
}

