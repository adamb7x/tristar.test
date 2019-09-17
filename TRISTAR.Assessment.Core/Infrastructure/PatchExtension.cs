namespace TRISTAR.Assessment.Infrastructure
{
    public static class PatchExtension
    {
        /// <summary>
        /// Applies a patch to the target object, copying the property values from <paramref name="delta"/> to <paramref name="target"/>.
        /// </summary>
        /// <typeparam name="TFrom"></typeparam>
        /// <typeparam name="TTo"></typeparam>
        /// <param name="delta"></param>
        /// <param name="target"></param>
        public static void Patch<TFrom, TTo>(this TFrom delta, TTo target)
            where TFrom : ITrackChanges
        {
            foreach (var change in delta.GetChangedProperties())
            {
                var targetProperty = typeof(TTo).GetProperty(change);
                if (targetProperty == null || !targetProperty.CanWrite)
                    continue;
                var sourceProperty = typeof(TFrom).GetProperty(change);
                if (sourceProperty == null || !targetProperty.CanRead)
                    continue;
                if (!targetProperty.PropertyType.IsAssignableFrom(sourceProperty.PropertyType))
                    continue;

                var sourceValue = sourceProperty.GetValue(delta, null);

                targetProperty.SetValue(target, sourceValue);
            }
        }
    }
}
