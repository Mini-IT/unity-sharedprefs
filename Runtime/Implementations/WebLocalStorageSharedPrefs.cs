#if UNITY_WEBGL && !UNITY_EDITOR

namespace MiniIT.Storage.Unity
{
	public class WebLocalStorageSharedPrefs : ISharedPrefs
	{
		private const string PREFIX = "MiniIT/Prefs/";

		public void DeleteAll()
		{
			WebLocalStorage.DeleteByPrefix(PREFIX);
		}

		public void DeleteKey(string key)
		{
			key = GetKey(key);
			WebLocalStorage.DeleteByPrefix(key);
		}

		public bool GetBool(string key, bool defaultValue = default)
		{
			key = GetKey(key);
			string value = WebLocalStorage.Read(key);
			if (int.TryParse(value, out int val))
			{
				return (val != 0);
			}
			return defaultValue;
		}

		public float GetFloat(string key, float defaultValue = default)
		{
			key = GetKey(key);
			string value = WebLocalStorage.Read(key);
			if (float.TryParse(value, out float val))
			{
				return val;
			}
			return defaultValue;
		}

		public int GetInt(string key, int defaultValue = default)
		{
			key = GetKey(key);
			string value = WebLocalStorage.Read(key);
			if (int.TryParse(value, out int val))
			{
				return val;
			}
			return defaultValue;
		}

		public string GetString(string key, string defaultValue = default)
		{
			key = GetKey(key);
			string value = WebLocalStorage.Read(key);
			if (string.IsNullOrEmpty(value))
			{
				return defaultValue;
			}
			return value;
		}

		public bool HasKey(string key)
		{
			return WebLocalStorage.HasKey(key);
		}

		public void Save()
		{
			// Do nothing
		}

		public void SetBool(string key, bool value)
		{
			SetInt(key, value ? 1 : 0);
		}

		public void SetFloat(string key, float value)
		{
			WebLocalStorage.Write(key, value.ToString());
		}

		public void SetInt(string key, int value)
		{
			WebLocalStorage.Write(key, value.ToString());
		}

		public void SetString(string key, string value)
		{
			WebLocalStorage.Write(key, value);
		}

		private string GetKey(string key)
		{
			return string.Concat(PREFIX, key);
		}
	}
}

#endif
