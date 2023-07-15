//
//  PureMVC C# Standard
//
//  Copyright(c) 2020 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

using System;

namespace PureMVC.Interfaces
{
    /// <summary>
    /// The interface definition for a PureMVC Facade.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         The Facade Pattern suggests providing a single
    ///         class to act as a central point of communication 
    ///         for a subsystem.
    ///     </para>
    ///     <para>
    ///         In PureMVC, the Facade acts as an interface between
    ///         the core MVC actors (Model, View, Controller) and
    ///         the rest of your application.
    ///     </para>
    /// </remarks>
    /// <seealso cref="IModel"/>
    /// <seealso cref="IView"/>
    /// <seealso cref="IController"/>
    /// <seealso cref="ICommand"/>
    /// <seealso cref="INotification"/>
    public interface IFacade : INotifier
    {
        /// <summary>
        /// 按名称向<c>Model</c>注册<c>IProxy</c>。
        /// </summary>
        /// <param name="proxy">要向<c>Model</c>注册的<c>IProxy</c>。</param>
        void RegisterProxy(IProxy proxy);

        /// <summary>
        /// 按名称从<c>Model</c>检索<c>IProxy</c>。
        /// </summary>
        /// <param name="proxyName">要检索的<c>IProxy</c>实例的名称。</param>
        /// <returns><c>IProxy</c>之前由<c>proxyName</c>向<c>Model</c>注册。</returns>
        IProxy RetrieveProxy(string proxyName);

        /// <summary>
        /// 按名称从<c>Model</c>中删除<c>IProxy</c>实例。
        /// </summary>
        /// <param name="proxyName">要从<c>Model</c>中删除的<c>IProxy</c>。</param>
        /// <returns>从<c>Model</c>中删除的<c>IProxy</c></returns>
        IProxy RemoveProxy(string proxyName);

        /// <summary>
        /// 检查Proxy是否已注册
        /// </summary>
        /// <param name="proxyName"></param>
        /// <returns>当前是否使用给定的<c>proxyName</c>注册代理。</returns>
        bool HasProxy(string proxyName);

        /// <summary>
        /// 向<c>Controller</c>注册一个<c>ICommand</c>。
        /// </summary>
        /// <param name="notificationName">与<c>ICommand</c>关联的<c>INotification</c>的名称。</param>
        /// <param name="factory">对<c>ICommand</c>的<c>FuncDelegate</c>的引用</param>
        void RegisterCommand(string notificationName, Func<ICommand> factory);

        /// <summary>
        /// 从Controller中删除先前注册的<c>ICommand</c>到<c>INotification</c>映射。
        /// </summary>
        /// <param name="notificationName">要删除其<c>ICommand</c>映射的<c>INotification</c>的名称</param>
        void RemoveCommand(string notificationName);

        /// <summary>
        /// Check if a Command is registered for a given Notification 
        /// </summary>
        /// <param name="notificationName"></param>
        /// <returns>whether a Command is currently registered for the given <c>notificationName</c>.</returns>
        bool HasCommand(string notificationName);

        /// <summary>
        /// Register an <c>IMediator</c> instance with the <c>View</c>.
        /// </summary>
        /// <param name="mediator">a reference to the <c>IMediator</c> instance</param>
        void RegisterMediator(IMediator mediator);

        /// <summary>
        /// Retrieve an <c>IMediator</c> instance from the <c>View</c>.
        /// </summary>
        /// <param name="mediatorName">the name of the <c>IMediator</c> instance to retrievve</param>
        /// <returns>the <c>IMediator</c> previously registered with the given <c>mediatorName</c>.</returns>
        IMediator RetrieveMediator(string mediatorName);

        /// <summary>
        /// Remove a <c>IMediator</c> instance from the <c>View</c>.
        /// </summary>
        /// <param name="mediatorName">name of the <c>IMediator</c> instance to be removed</param>
        /// <returns>the <c>IMediator</c> instance previously registered with the given <c>mediatorName</c>.</returns>
        IMediator RemoveMediator(string mediatorName);

        /// <summary>
        /// Check if a Mediator is registered or not
        /// </summary>
        /// <param name="mediatorName"></param>
        /// <returns>whether a Mediator is registered with the given <c>mediatorName</c>.</returns>
        bool HasMediator(string mediatorName);

        /// <summary>
        /// Notify <c>Observer</c>s.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         This method is left public mostly for backward 
        ///         compatibility, and to allow you to send custom 
        ///         notification classes using the facade.
        ///     </para>
        ///     <para>
        ///         Usually you should just call sendNotification
        ///         and pass the parameters, never having to 
        ///         construct the notification yourself.
        ///     </para>
        /// </remarks>
        /// <param name="notification">the <c>INotification</c> to have the <c>View</c> notify <c>Observers</c> of.</param>
        void NotifyObservers(INotification notification);
    }
}
