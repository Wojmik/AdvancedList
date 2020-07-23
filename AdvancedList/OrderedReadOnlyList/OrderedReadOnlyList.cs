﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using WojciechMikołajewicz.AdvancedList.OrderedReadOnlyList.Internal;

namespace WojciechMikołajewicz.AdvancedList
{
	public abstract class OrderedReadOnlyList<T> : IReadOnlyList<T>
	{
		private protected T[] _Array;

		public T this[int index] { get => this._Array[index]; }

		public int Count { get => this._Array.Length; }

		public OrderedReadOnlyList(IEnumerable<T> collection, IEnumerable<KeyData<T>> keyData)
		{
			const int startChunk = 256;
			bool shouldSort = false;
			ItemComparer<T> itemComparer = new ItemComparer<T>(keyData);

			if(collection is IReadOnlyCollection<T> roColl)
			{
				this._Array=new T[roColl.Count];

				using(var enumerator = collection.GetEnumerator())
				{
					if(enumerator.MoveNext())
					{
						int i = 0;
						this._Array[i]=enumerator.Current;

						while(enumerator.MoveNext())
						{
							if(!shouldSort)
								shouldSort=0<itemComparer.Compare(this._Array[i], enumerator.Current);
							i++;
							this._Array[i]=enumerator.Current;
						}
					}
				}
			}
			else
			{
				LinkedList<T[]> chunksList = new LinkedList<T[]>();

				using(var enumerator = collection.GetEnumerator())
				{
					if(enumerator.MoveNext())
					{
						T[] currentChunk = new T[startChunk];
						int i = 0;

						chunksList.AddLast(currentChunk);
						currentChunk[i]=enumerator.Current;

						while(enumerator.MoveNext())
						{
							if(!shouldSort)
								shouldSort=0<itemComparer.Compare(currentChunk[i], enumerator.Current);
							i++;
							if(currentChunk.Length<=i)
							{
								//New chunk required
								currentChunk=new T[checked(currentChunk.Length*2)];
								i=0;
								chunksList.AddLast(currentChunk);
							}
							currentChunk[i]=enumerator.Current;
						}
						this._Array=new T[-startChunk*(1-(int)Math.Pow(2, chunksList.Count-1))+i];
					}
					else
						this._Array=new T[0];
				}
			}

			//Sort array if required
			if(shouldSort)
				Array.Sort(this._Array, itemComparer);
		}

		public IEnumerator<T> GetEnumerator()
		{
			return ((IEnumerable<T>)this._Array).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}
}