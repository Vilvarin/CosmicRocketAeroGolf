using System;
using UnityEngine;
using CRAG;

namespace CRAG.InputSystem
{
    /// <summary>
    /// Обощенный интерфейс для комманд управления.
    /// </summary>
    /// <typeparam name="T">Тип исполнителя команды</typeparam>
    public interface ICommand<T>
    {
        /// <summary>
        /// Выполнение инструкций для исполнителя.
        /// </summary>
        /// <param name="actor">Исполнитель команды</param>
        void Execute(T actor);
    }

    /// <summary>
    /// Интерфейс для комманд управления.
    /// </summary>
    /// <remarks>Использовать для команд обработчику, статическим классам или одиночкам</remarks>
    public interface ICommand
    {
        /// <summary>
        /// Выполнение инструкций
        /// </summary>
        void Execute();
    }
}

