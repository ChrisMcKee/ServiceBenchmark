 /**
 * Base ASP.NET WebForms page using ServiceStack's Compontents, see: http://www.servicestack.net/mvc-powerpack/
 */

namespace ServiceBenchmark.SvcStack.App_Start
{
	using System.Web.UI;
	using ServiceStack.CacheAccess;
	using ServiceStack.ServiceInterface;
	using ServiceStack.ServiceInterface.Auth;
	using ServiceStack.WebHost.Endpoints;

	//A customizeable typed UserSession that can be extended with your own properties
	public class CustomUserSession : AuthUserSession
	{
		public string CustomProperty { get; set; }
	}

	public class PageBase : Page
	{
		/// <summary>
		///     Dynamic Session Bag
		/// </summary>
		private ISession session;

		private ISessionFactory sessionFactory;

		/// <summary>
		///     Typed UserSession
		/// </summary>
		private object userSession;

		protected CustomUserSession UserSession
		{
			get { return SessionAs<CustomUserSession>(); }
		}

		public new ICacheClient Cache
		{
			get { return AppHostBase.Resolve<ICacheClient>(); }
		}

		public virtual ISessionFactory SessionFactory
		{
			get { return sessionFactory ?? (sessionFactory = AppHostBase.Resolve<ISessionFactory>()) ?? new SessionFactory(Cache); }
		}

		public new ISession Session
		{
			get { return session ?? (session = SessionFactory.GetOrCreateSession()); }
		}

		protected virtual TUserSession SessionAs<TUserSession>()
		{
			return (TUserSession) (userSession ?? (userSession = Cache.SessionAs<TUserSession>()));
		}

		public void ClearSession()
		{
			userSession = null;
			this.Cache.Remove(SessionFeature.GetSessionKey());
		}
	}
}