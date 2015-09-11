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

        //Команды игрока
        private ICommand<GameActor> _leftMouseButtonDown  = new ImpulseCommand();
        private ICommand<GameActor> _rightMouseButtonDown = new EnterCommand();
        private ICommand<GameActor> _rightMouseButtonUp   = new DescendCommand();
        
        //Состояния для обработки в FixedUpdate()
        private bool _impulseState = false;
        private bool _enterstate   = false;
        private bool _descendState = false;
 
        //Команды игры
        private ICommand _escapeButton = new ExitCommand();
        private ICommand _rButton      = new RestartCommand();
        private ICommand _spaceButton  = new ClosePanelCommand();

        //Команды камеры
        private ICommand<IsometricCamera> _scrollUp = new ZoomCamCommand(1f);
        private ICommand<IsometricCamera> _scrollDown = new ZoomCamCommand(-1f);

        void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                _escapeButton.Execute();
            if (Input.GetKeyDown(KeyCode.R))
                _rButton.Execute();
            if (Input.GetKeyDown(KeyCode.Space))
                _spaceButton.Execute();

            if (Input.GetAxis("Mouse ScrollWheel") > 0)
                _scrollUp.Execute(cam);
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
                _scrollDown.Execute(cam);
            
            if (playerState)
            {
                if (Input.GetMouseButtonDown(0))
                    _impulseState = true;
                if (Input.GetMouseButtonDown(1))
                    _enterstate   = true;
                if (Input.GetMouseButtonUp(1))
                    _descendState = true;
            }
        }

        void FixedUpdate()
        {
            if (_impulseState)
            {
                _impulseState = false;
                _leftMouseButtonDown.Execute(player);
            }

            if (_enterstate)
            {
                _enterstate = false;
                _rightMouseButtonDown.Execute(player);
            }
            if (_descendState)
            {
                _descendState = false;
                _rightMouseButtonUp.Execute(player);
            }
        }
    }
}

