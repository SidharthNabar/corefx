// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections;
using System.Text;
using Xunit;

namespace System.Collections.SortedListTests
{
    public class ValuesTests
    {
        [Fact]
        public void TestGetValuesBasic()
        {
            SortedList sl = null;
            ICollection ic = null;
            IEnumerator ie = null;
            int iNumItems = 100;

            // Get an ICollection to Values and make sure there is correct number of them
            sl = new SortedList();

            // add elements to SortedList
            for (int i = 0; i < iNumItems; i++)
            {
                sl.Add(i, i);
            }

            ic = sl.Values;
            Assert.Equal(ic.Count, iNumItems);


            // Get an ICollection to Values and make sure enumerator throws without MoveNext
            Assert.Throws<InvalidOperationException>(() =>
                     {
                         sl = new SortedList();

                         // add elements to SortedList
                         for (int i = 0; i < iNumItems; i++)
                         {
                             sl.Add(i, i);
                         }

                         ic = sl.Values;
                         ie = (IEnumerator)ic.GetEnumerator();
                         object garbageobj = ie.Current; // should throw exception
                     }
            );

            // Get an ICollection to Values and make sure we can enumerate through the collection
            {
                sl = new SortedList();

                // add elements to SortedList
                for (int i = 0; i < iNumItems; i++)
                {
                    sl.Add(i, i);
                }

                ic = sl.Values;

                ie = (IEnumerator)ic.GetEnumerator();

                int iCounter = 0; // keeps track of how many objects there are in enumeration
                while (ie.MoveNext())
                {
                    object o = ie.Current;

                    Assert.NotNull(o);


                    Assert.True(o.Equals(iCounter), "Error, element should not be " + o.ToString() + " but it should be " + iCounter.ToString());
                    iCounter++;
                }

                Assert.Equal(iCounter, iNumItems);
            }

            Assert.Throws<InvalidOperationException>(() =>
                     {
                         sl = new SortedList();

                         // add elements to SortedList
                         for (int i = 0; i < iNumItems; i++)
                         {
                             sl.Add(i, i);
                         }

                         ic = sl.Values;
                         ie = (IEnumerator)ic.GetEnumerator();

                         // make change to underlying collection
                         sl.Add(iNumItems, iNumItems);

                         ie.MoveNext();
                     }
            );


            // Get ICollection to Values make sure that CopyTo throws with incorrect arguments 1
            Assert.Throws<ArgumentNullException>(() =>
                     {
                         sl = new SortedList();

                         // add elements to SortedList
                         for (int i = 0; i < iNumItems; i++)
                         {
                             sl.Add(i, i);
                         }

                         ic = sl.Values;

                         ic.CopyTo(null, 0);
                     }
            );

            // Get ICollection to Values make sure that CopyTo throws with incorrect arguments 2
            Assert.Throws<ArgumentException>(() =>
                     {
                         sl = new SortedList();

                         // add elements to SortedList
                         for (int i = 0; i < iNumItems; i++)
                         {
                             sl.Add(i, i);
                         }

                         ic = sl.Values;

                         object[] obj = new object[iNumItems];
                         // incorrect reference into array
                         ic.CopyTo(obj, iNumItems);
                     }
            );
        }
    }
}
