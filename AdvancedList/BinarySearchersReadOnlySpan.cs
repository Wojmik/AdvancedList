﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WojciechMikołajewicz.AdvancedList
{
	public static partial class BinarySearchers
	{
		/// <summary>
		/// Return span of items equal to searched one.
		/// <paramref name="span"/> has to be sorted and <paramref name="comparison"/> method has to use same sorting.
		/// </summary>
		/// <typeparam name="T">Type of items</typeparam>
		/// <param name="span">Sorted span</param>
		/// <param name="comparison">Method should determine whether the searching item is less (-1), equal (0) or greater (1) than passed one (SearchingItem.CompareTo(item))</param>
		/// <returns>Span of items in <paramref name="span"/> equals to serched one</returns>
		public static ReadOnlySpan<T> BinaryFindEqual<T>(this in ReadOnlySpan<T> span, Func<T, int> comparison)
		{
			var greaterOrEqual = BinaryFindGreaterOrEqual(span, comparison);
			return BinaryFindLessOrEqual(greaterOrEqual, comparison);
		}

		/// <summary>
		/// Return span of items less or equal to searched one.
		/// <paramref name="span"/> has to be sorted and <paramref name="comparison"/> method has to use same sorting.
		/// </summary>
		/// <typeparam name="T">Type of items</typeparam>
		/// <param name="span">Sorted span</param>
		/// <param name="comparison">Method should determine whether the searching item is less (-1), equal (0) or greater (1) than passed one (SearchingItem.CompareTo(item))</param>
		/// <returns>Span of items in <paramref name="span"/> less or equals to serched one</returns>
		public static ReadOnlySpan<T> BinaryFindLessOrEqual<T>(this in ReadOnlySpan<T> span, Func<T, int> comparison)
		{
			int left = 0, right = span.Length-1, current, cmp;

			while(left<=right)
			{
				//Take middle item
				current=(left+right)>>1;
				//Compare current item with searched one
				cmp=comparison(span[current]);
				//Check comparison result
				if(0>cmp)//The searched item is located in the left part of the range
					right=current-1;
				else//The searched item was found. But we want the last one - so check if the next one also meets the conditions
					if(current+1>=span.Length || 0>(cmp=comparison(span[current+1])))//There is no next item or is greater than the searched one, so current item is the last matching one
				{
					//The last searched item was found
					return span.Slice(0, current+1);
				}
				else//The next item also matches, so it is not the last one that meets the conditions, so the searched element is in the right part of the range
					left=current+1;
			}

			return ReadOnlySpan<T>.Empty;
		}

		/// <summary>
		/// Return span of items less than searched one.
		/// <paramref name="span"/> has to be sorted and <paramref name="comparison"/> method has to use same sorting.
		/// </summary>
		/// <typeparam name="T">Type of items</typeparam>
		/// <param name="span">Sorted span</param>
		/// <param name="comparison">Method should determine whether the searching item is less (-1), equal (0) or greater (1) than passed one (SearchingItem.CompareTo(item))</param>
		/// <returns>Span of items in <paramref name="span"/> less than serched one</returns>
		public static ReadOnlySpan<T> BinaryFindLess<T>(this in ReadOnlySpan<T> span, Func<T, int> comparison)
		{
			int left = 0, right = span.Length-1, current, cmp;

			while(left<=right)
			{
				//Take middle item
				current=(left+right)>>1;
				//Compare current item with searched one
				cmp=comparison(span[current]);
				//Check comparison result
				if(0>=cmp)//The searched item is located in the left part of the range
					right=current-1;
				else//The searched item was found. But we want the last one - so check if the next one also meets the conditions
					if(current+1>=span.Length || 0>=(cmp=comparison(span[current+1])))//There is no next item or is greater or equal to the searched one, so current item is the last matching one
				{
					//The last searched item was found
					return span.Slice(0, current+1);
				}
				else//The next item also matches, so it is not the last one that meets the conditions, so the searched element is in the right part of the range
					left=current+1;
			}

			return ReadOnlySpan<T>.Empty;
		}

		/// <summary>
		/// Return span of items greater or equal to searched one.
		/// <paramref name="span"/> has to be sorted and <paramref name="comparison"/> method has to use same sorting.
		/// </summary>
		/// <typeparam name="T">Type of items</typeparam>
		/// <param name="span">Sorted span</param>
		/// <param name="comparison">Method should determine whether the searching item is less (-1), equal (0) or greater (1) than passed one (SearchingItem.CompareTo(item))</param>
		/// <returns>Span of items in <paramref name="span"/> greater or equals to serched one</returns>
		public static ReadOnlySpan<T> BinaryFindGreaterOrEqual<T>(this in ReadOnlySpan<T> span, Func<T, int> comparison)
		{
			int left = 0, right = span.Length-1, current, cmp;

			while(left<=right)
			{
				//Take middle item
				current=(left+right)>>1;
				//Compare current item with searched one
				cmp=comparison(span[current]);
				//Check comparison result
				if(0<cmp)//The searched item is located in the right part of the range
					left=current+1;
				else//The searched item was found. But we want the first one - so check if the previous one also meets the conditions
					if(current<=0 || 0<(cmp=comparison(span[current-1])))//There is no previous item or is less than the searched one, so current item is the first matching one
				{
					//The first searched item was found
					return span.Slice(current);
				}
				else//The previous item also matches, so it is not the first one that meets the conditions, so the searched element is in the left part of the range
					right=current-1;
			}

			return ReadOnlySpan<T>.Empty;
		}

		/// <summary>
		/// Return span of items greater than searched one.
		/// <paramref name="span"/> has to be sorted and <paramref name="comparison"/> method has to use same sorting.
		/// </summary>
		/// <typeparam name="T">Type of items</typeparam>
		/// <param name="span">Sorted span</param>
		/// <param name="comparison">Method should determine whether the searching item is less (-1), equal (0) or greater (1) than passed one (SearchingItem.CompareTo(item))</param>
		/// <returns>Span of items in <paramref name="span"/> greater than serched one</returns>
		public static ReadOnlySpan<T> BinaryFindGreater<T>(this in ReadOnlySpan<T> span, Func<T, int> comparison)
		{
			int left = 0, right = span.Length-1, current, cmp;

			while(left<=right)
			{
				//Take middle item
				current=(left+right)>>1;
				//Compare current item with searched one
				cmp=comparison(span[current]);
				//Check comparison result
				if(0<=cmp)//The searched item is located in the right part of the range
					left=current+1;
				else//The searched item was found. But we want the first one - so check if the previous one also meets the conditions
					if(current<=0 || 0<=(cmp=comparison(span[current-1])))//There is no previous item or is less or equal to the searched one, so current item is the first matching one
				{
					//The first searched item was found
					return span.Slice(current);
				}
				else//The previous item also matches, so it is not the first one that meets the conditions, so the searched element is in the left part of the range
					right=current-1;
			}

			return ReadOnlySpan<T>.Empty;
		}
	}
}