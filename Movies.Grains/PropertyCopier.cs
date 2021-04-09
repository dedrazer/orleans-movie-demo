using System.Linq;

namespace Movies.Grains
{
	public static class PropertyCopier
	{
		public static void CopyProperties<T, TU>(this T source, TU dest, bool copyNulls = true)
		{
			var sourceProps = typeof(T).GetProperties().Where(x => x.CanRead).ToList();
			var destProps = typeof(TU).GetProperties()
					.Where(x => x.CanWrite)
					.ToList();

			foreach (var sourceProp in sourceProps)
			{
				if (destProps.Any(x => x.Name == sourceProp.Name))
				{
					var p = destProps.First(x => x.Name == sourceProp.Name);

					// check if the property can be set or no.
					// only copy null values if specified
					if (p.CanWrite 
						&& (copyNulls || (!copyNulls && sourceProp.GetValue(source, null) != null)))
					{
						p.SetValue(dest, sourceProp.GetValue(source, null), null);
					}
				}

			}

		}
	}
}
