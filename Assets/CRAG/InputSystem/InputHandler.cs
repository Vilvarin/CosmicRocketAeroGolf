using UnityEngine;
using System.Collections.Generic;
using UnityStandardAssets.Cameras;

namespace CRAG.InputSystem
{
    /// <summary>
    /// Обработчик команд управления.
    /// </summary>
    public class InputHandler : MonoBehaviour
    {
        public static InputHandler instance;

        ///<summary>Исполнитель команд игровому персонажу</summary>
        public GameActor player;
        ///<summary>Исполнитель команд камеры</summary>
        public IsometricCamera cam;

        ///<summary>Переключатель для состояния, в котором игровой персонаж в состоянии исполнять команды.</summary>
        [HideInInspector] public bool playerState = true;

        /// <summary>Список команд выполняемых в Update()</summary>
        private List<ICommand> _updateCommands = new List<ICommand>();
        ///<summary>Список команд выполняемых в FixedUpdate()</summary>
        private List<ICommand<GameActor>> _fixCommands = new List<ICommand<GameActor>>();

        void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);
        }

        void ExecuteCamCommand()
        {
            if (Input.GetAxis("Mouse ScrollWheel") != 0)
                new ZoomCamCommand(Input.GetAxis("Mouse ScrollWheel")).Execute(cam);
        }

        void AddUpdateCommand()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                _updateCommands.Add(new ClosePanelCommand());
            if (Input.GetKeyDown(KeyCode.R))
                _updateCommands.Add(new RestartCommand());
            if (Input.GetKeyDown(KeyCode.Escape))
                _updateCommands.Add(new ExitCommand());
        }

        void AddFixedUpdateCommand()
        {
            if (playerState)
            {
                if (Input.GetMouseButtonDown(0))
                    _fixCommands.Add(new ImpulseCommand());
                if (Input.GetMouseButtonDown(1))
                    _fixCommands.Add(new EnterCommand());
                if (Input.GetMouseButtonUp(1))
                    _fixCommands.Add(new DescendCommand());
            }
        }

        //Добавление комманды в список позволяет выполнить 
        //несколько команд в течении одного кадра.
        //Ради отзывчивого управления.
        void Update()
        {
            AddUpdateCommand();
            AddFixedUpdateCommand();

            foreach (ICommand command in _updateCommands)
                command.Execute();

            ExecuteCamCommand();

            _updateCommands.Clear(); //Чистим выполненные команды, чтобы не мешались в следующем кадре
        }

        void FixedUpdate()
        {
            foreach (ICommand<GameActor> command in _fixCommands)
                command.Execute(player);

            _fixCommands.Clear();
        }
    }
}

