#if UNITY_WEBGL && !UNITY_EDITOR

using System.Collections.Generic;

namespace MiniIT.Storage.Migrations
{
	public static class MigrationCookiesToLocalStorage
	{
		public static void Run(ISharedPrefs prefs)
		{
#if MINIIT_COOKIES
			Dictionary<string, string> all = HttpCookie.GetAllCookies();
			foreach (var pair in all)
			{
				UnityEngine.Debug.Log("[MigrationCookiesToLocalStorage] " + pair.Key + ":" + pair.Value);

				prefs.SetString(pair.Key, pair.Value);
				HttpCookie.RemoveCookie(pair.Key);
			}
#endif
		}
	}
}

#endif
