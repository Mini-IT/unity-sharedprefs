using MiniIT.Storage.Unity;

namespace MiniIT.Storage
{
	public static class SharedPrefs
	{
		public static ISharedPrefs Instance => s_instance ??= CreateSharedPrefs();

		private static ISharedPrefs s_instance;

		private static ISharedPrefs CreateSharedPrefs() =>
#if UNITY_WEBGL && !UNITY_EDITOR
			new WebGLSharedPrefs();
#else
			new UnitySharedPrefs();
#endif

		#region Static ISharedPrefs

		public static void DeleteAll()
		{
			Instance.DeleteAll();
		}

		public static void DeleteKey(string key)
		{
			Instance.DeleteKey(key);
		}

		public static bool GetBool(string key, bool defaultValue = default)
		{
			return Instance.GetInt(key, defaultValue ? 1 : 0) != 0;
		}

		public static float GetFloat(string key, float defaultValue = default)
		{
			return Instance.GetFloat(key, defaultValue);
		}

		public static int GetInt(string key, int defaultValue = default)
		{
			return Instance.GetInt(key, defaultValue);
		}

		public static string GetString(string key, string defaultValue = default)
		{
			return Instance.GetString(key, defaultValue);
		}

		public static bool HasKey(string key)
		{
			return Instance.HasKey(key);
		}

		public static void Save()
		{
			Instance.Save();
		}

		public static void SetBool(string key, bool value)
		{
			Instance.SetInt(key, value ? 1 : 0);
		}

		public static void SetFloat(string key, float value)
		{
			Instance.SetFloat(key, value);
		}

		public static void SetInt(string key, int value)
		{
			Instance.SetInt(key, value);
		}

		public static void SetString(string key, string value)
		{
			Instance.SetString(key, value);
		}

		#endregion
	}
}
