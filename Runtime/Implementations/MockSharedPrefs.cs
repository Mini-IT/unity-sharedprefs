using System.Collections.Generic;

namespace MiniIT.Storage
{
	public sealed class MockSharedPrefs : ISharedPrefs
	{
		private readonly Dictionary<string, object> _values = new Dictionary<string, object>();

		public void DeleteAll()
		{
			_values.Clear();
		}

		public void DeleteKey(string key)
		{
			_values.Remove(key);
		}

		public bool GetBool(string key, bool defaultValue = false)
		{
			if (_values.TryGetValue(key, out object value))
			{
				if (value is bool boolValue)
				{
					return boolValue;
				}

				if (value is int intValue)
				{
					return intValue != 0;
				}
			}

			return defaultValue;
		}

		public float GetFloat(string key, float defaultValue = 0)
		{
			if (_values.TryGetValue(key, out object value) && value is float floatValue)
			{
				return floatValue;
			}

			return defaultValue;
		}

		public int GetInt(string key, int defaultValue = 0)
		{
			if (_values.TryGetValue(key, out object value))
			{
				if (value is int intValue)
				{
					return intValue;
				}

				if (value is bool boolValue)
				{
					return boolValue ? 1 : 0;
				}
			}

			return defaultValue;
		}

		public string GetString(string key, string defaultValue = null)
		{
			if (_values.TryGetValue(key, out object value) && value is string stringValue)
			{
				return stringValue;
			}

			return defaultValue;
		}

		public bool HasKey(string key)
		{
			return _values.ContainsKey(key);
		}

		public void Save()
		{
		}

		public void SetBool(string key, bool value)
		{
			_values[key] = value;
		}

		public void SetFloat(string key, float value)
		{
			_values[key] = value;
		}

		public void SetInt(string key, int value)
		{
			_values[key] = value;
		}

		public void SetString(string key, string value)
		{
			_values[key] = value;
		}
	}
}
