using UnityEngine;
using System.Collections.Generic;

namespace CRAG.InputSystem
{
    /// <summary>
    /// Обработчик команд управления.
    /// </summary>
    public class InputHandler : MonoBehaviour
    {
        ///<summary>Исполнитель команд игровому персонажу</summary>
        public GameActor player;

        ///<summary>Переключатель для состояния, в котором игровой персонаж в состоянии исполнять команды.</summary>
        [HideInInspector] public bool playerState = true;
        

        public static InputHandler instance;

        private List<ICommand> _updateCommands = new List<ICommand>();///<summary>Список команд выполняемых в Update()</summary>
        private List<ICommand<GameActor>> _fixCommands = new List<ICommand<GameActor>>();///<summary>Список команд выполняемых в FixedUpdate()</summary>

        void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);
        }

        //Добавление комманды в список позволяет выполнить 
        //несколько команд в течении одного кадра.
        //Ради отзывчивого управления.
        void Update()
        {
            //Записали команды для персонажа. Исполняются в FixefUpdate()
            if (Input.GetMouseButtonDown(0))
                _fixCommands.Add(new ImpulseCommand());
            if (Input.GetMouseButton(1))
                _fixCommands.Add(new EnterCommand());
            if (Input.GetMouseButtonUp(1))
                _fixCommands.Add(new DescendCommand());

            //Команды интерфейса. Исполняются тут же.
            if (Input.GetKeyDown(KeyCode.Space))
                _updateCommands.Add(new ClosePanelCommand());
            if (Input.GetKeyDown(KeyCode.R))
                _updateCommands.Add(new RestartCommand());
            if (Input.GetKeyDown(KeyCode.Escape))
                _updateCommands.Add(new ExitCommand());

            foreach (ICommand command in _updateCommands)
                command.Execute();

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

