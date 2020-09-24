﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using WojciechMikołajewicz.SortedList.KeysData;

namespace WojciechMikołajewicz.SortedList
{
	/// <summary>
	/// Part of sorted read only list with binary search based on items compare (not items equality)
	/// </summary>
	/// <typeparam name="T">Items type</typeparam>
	/// <typeparam name="K1">Key1 type</typeparam>
	/// <typeparam name="K2">Key2 type</typeparam>
	/// <typeparam name="K3">Key3 type</typeparam>
	/// <typeparam name="K4">Key4 type</typeparam>
	/// <typeparam name="K5">Key5 type</typeparam>
	public readonly struct SortedReadOnlyListRange<T, K1, K2, K3, K4, K5> : IReadOnlyList<T>
	{
		#region Common
		/// <summary>
		/// Implicit cast operator
		/// </summary>
		/// <param name="orderedReadOnlyList">Sorted read only list</param>
		public static implicit operator SortedReadOnlyListRange<T, K1, K2, K3, K4, K5>(SortedReadOnlyList<T, K1, K2, K3, K4, K5> orderedReadOnlyList) => new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5>(orderedReadOnlyList, new Range(0, orderedReadOnlyList.Count));

		/// <summary>
		/// Keys data
		/// </summary>
		private KeysData<T, K1, K2, K3, K4, K5> KeysData { get; }

		/// <summary>
		/// Memory of the part of source sorted read only list
		/// </summary>
		public ReadOnlyMemory<T> Memory { get; }

		/// <summary>
		/// Number of items
		/// </summary>
		public int Count { get => this.Memory.Length; }

		/// <summary>
		/// Is empty
		/// </summary>
		public bool IsEmpty { get => this.Memory.IsEmpty; }

		/// <summary>
		/// Returns an item of <paramref name="index"/>
		/// </summary>
		/// <param name="index">Index of the item to return</param>
		/// <returns>Item of specified <paramref name="index"/></returns>
		public T this[int index] { get => this.Memory.Span[index]; }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="orderedList">Source sorted read only list</param>
		/// <param name="range">Range in the <paramref name="orderedList"/></param>
		public SortedReadOnlyListRange(SortedReadOnlyList<T, K1, K2, K3, K4, K5> orderedList, Range range)
		{
			(int start, int count) = range.GetOffsetAndLength(orderedList.Count);
			this.KeysData=orderedList;
			this.Memory=orderedList.AsMemory().Slice(start, count);
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="keysData">Keys data</param>
		/// <param name="memory">Read only memory of sorted read only list</param>
		private SortedReadOnlyListRange(KeysData<T, K1, K2, K3, K4, K5> keysData, ReadOnlyMemory<T> memory)
		{
			this.KeysData=keysData;
			this.Memory=memory;
		}

		/// <summary>
		/// Get enumerator
		/// </summary>
		/// <returns>Enumerator</returns>
		public IEnumerator<T> GetEnumerator()
		{
			return new Internal.OrderedReadOnlyListRangeEnumerator<T>(this.Memory);
		}

		/// <summary>
		/// Get enumerator
		/// </summary>
		/// <returns>Enumerator</returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
		#endregion

		#region Equal
		/// <summary>
		/// Get part of the list of elements equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <returns>Part of the list of elements equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5> BinaryFindEqual(K1 key1)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindEqual(Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5>(orderedList, newMemory);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1);
			}
		}

		/// <summary>
		/// Get part of the list of elements equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <returns>Part of the list of elements equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5> BinaryFindEqual(K1 key1, K2 key2)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindEqual(Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5>(orderedList, newMemory);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2);
			}
		}

		/// <summary>
		/// Get part of the list of elements equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <returns>Part of the list of elements equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5> BinaryFindEqual(K1 key1, K2 key2, K3 key3)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindEqual(Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5>(orderedList, newMemory);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3);
			}
		}

		/// <summary>
		/// Get part of the list of elements equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <returns>Part of the list of elements equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5> BinaryFindEqual(K1 key1, K2 key2, K3 key3, K4 key4)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindEqual(Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5>(orderedList, newMemory);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4);
			}
		}

		/// <summary>
		/// Get part of the list of elements equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <param name="key5">Key 5 value</param>
		/// <returns>Part of the list of elements equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5> BinaryFindEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindEqual(Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5>(orderedList, newMemory);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5);
			}
		}
		#endregion

		#region LessOrEqual
		/// <summary>
		/// Get part of the list of elements less or equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <returns>Part of the list of elements less or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5> BinaryFindLessOrEqual(K1 key1)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLessOrEqual(Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5>(orderedList, newMemory);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1);
			}
		}

		/// <summary>
		/// Get part of the list of elements less or equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <returns>Part of the list of elements less or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5> BinaryFindLessOrEqual(K1 key1, K2 key2)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLessOrEqual(Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5>(orderedList, newMemory);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2);
			}
		}

		/// <summary>
		/// Get part of the list of elements less or equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <returns>Part of the list of elements less or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5> BinaryFindLessOrEqual(K1 key1, K2 key2, K3 key3)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLessOrEqual(Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5>(orderedList, newMemory);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3);
			}
		}

		/// <summary>
		/// Get part of the list of elements less or equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <returns>Part of the list of elements less or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5> BinaryFindLessOrEqual(K1 key1, K2 key2, K3 key3, K4 key4)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLessOrEqual(Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5>(orderedList, newMemory);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4);
			}
		}

		/// <summary>
		/// Get part of the list of elements less or equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <param name="key5">Key 5 value</param>
		/// <returns>Part of the list of elements less or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5> BinaryFindLessOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLessOrEqual(Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5>(orderedList, newMemory);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5);
			}
		}
		#endregion

		#region Less
		/// <summary>
		/// Get part of the list of elements less than specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <returns>Part of the list of elements less than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5> BinaryFindLess(K1 key1)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLess(Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5>(orderedList, newMemory);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1);
			}
		}

		/// <summary>
		/// Get part of the list of elements less than specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <returns>Part of the list of elements less than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5> BinaryFindLess(K1 key1, K2 key2)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLess(Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5>(orderedList, newMemory);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2);
			}
		}

		/// <summary>
		/// Get part of the list of elements less than specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <returns>Part of the list of elements less than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5> BinaryFindLess(K1 key1, K2 key2, K3 key3)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLess(Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5>(orderedList, newMemory);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3);
			}
		}

		/// <summary>
		/// Get part of the list of elements less than specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <returns>Part of the list of elements less than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5> BinaryFindLess(K1 key1, K2 key2, K3 key3, K4 key4)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLess(Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5>(orderedList, newMemory);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4);
			}
		}

		/// <summary>
		/// Get part of the list of elements less than specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <param name="key5">Key 5 value</param>
		/// <returns>Part of the list of elements less than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5> BinaryFindLess(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindLess(Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5>(orderedList, newMemory);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5);
			}
		}
		#endregion

		#region GreaterOrEqual
		/// <summary>
		/// Get part of the list of elements greater or equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <returns>Part of the list of elements greater or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5> BinaryFindGreaterOrEqual(K1 key1)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreaterOrEqual(Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5>(orderedList, newMemory);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1);
			}
		}

		/// <summary>
		/// Get part of the list of elements greater or equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <returns>Part of the list of elements greater or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5> BinaryFindGreaterOrEqual(K1 key1, K2 key2)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreaterOrEqual(Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5>(orderedList, newMemory);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2);
			}
		}

		/// <summary>
		/// Get part of the list of elements greater or equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <returns>Part of the list of elements greater or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5> BinaryFindGreaterOrEqual(K1 key1, K2 key2, K3 key3)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreaterOrEqual(Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5>(orderedList, newMemory);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3);
			}
		}

		/// <summary>
		/// Get part of the list of elements greater or equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <returns>Part of the list of elements greater or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5> BinaryFindGreaterOrEqual(K1 key1, K2 key2, K3 key3, K4 key4)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreaterOrEqual(Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5>(orderedList, newMemory);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4);
			}
		}

		/// <summary>
		/// Get part of the list of elements greater or equal to specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <param name="key5">Key 5 value</param>
		/// <returns>Part of the list of elements greater or equal to specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5> BinaryFindGreaterOrEqual(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreaterOrEqual(Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5>(orderedList, newMemory);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5);
			}
		}
		#endregion

		#region Greater
		/// <summary>
		/// Get part of the list of elements greater than specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <returns>Part of the list of elements greater than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5> BinaryFindGreater(K1 key1)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreater(Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5>(orderedList, newMemory);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1);
			}
		}

		/// <summary>
		/// Get part of the list of elements greater than specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <returns>Part of the list of elements greater than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5> BinaryFindGreater(K1 key1, K2 key2)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreater(Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5>(orderedList, newMemory);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2);
			}
		}

		/// <summary>
		/// Get part of the list of elements greater than specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <returns>Part of the list of elements greater than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5> BinaryFindGreater(K1 key1, K2 key2, K3 key3)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreater(Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5>(orderedList, newMemory);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3);
			}
		}

		/// <summary>
		/// Get part of the list of elements greater than specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <returns>Part of the list of elements greater than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5> BinaryFindGreater(K1 key1, K2 key2, K3 key3, K4 key4)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreater(Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5>(orderedList, newMemory);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4);
			}
		}

		/// <summary>
		/// Get part of the list of elements greater than specified keys values
		/// </summary>
		/// <param name="key1">Key 1 value</param>
		/// <param name="key2">Key 2 value</param>
		/// <param name="key3">Key 3 value</param>
		/// <param name="key4">Key 4 value</param>
		/// <param name="key5">Key 5 value</param>
		/// <returns>Part of the list of elements greater than specified keys values</returns>
		public SortedReadOnlyListRange<T, K1, K2, K3, K4, K5> BinaryFindGreater(K1 key1, K2 key2, K3 key3, K4 key4, K5 key5)
		{
			var orderedList = this.KeysData;

			var newMemory = Memory.BinaryFindGreater(Comparison);

			return new SortedReadOnlyListRange<T, K1, K2, K3, K4, K5>(orderedList, newMemory);

			int Comparison(T item)
			{
				return orderedList.Compare(item, key1, key2, key3, key4, key5);
			}
		}
		#endregion
	}
}