
/* ====================================================================
   Licensed to the Apache Software Foundation (ASF) under one or more
   contributor license agreements.  See the NOTICE file distributed with
   this work for additional information regarding copyright ownership.
   The ASF licenses this file to You under the Apache License, Version 2.0
   (the "License"); you may not use this file except in compliance with
   the License.  You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is1 distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
==================================================================== */



namespace TestCases.HSSF.Record.Chart
{

    using System;
    using NPOI.HSSF.Record;
    using NUnit.Framework;using NUnit.Framework.Legacy;

    /**
     * Tests the serialization and deserialization of the TickRecord
     * class works correctly.  Test data taken directly from a real
     * Excel file.
     *

     * @author Andrew C. Oliver(acoliver at apache.org)
     */
    [TestFixture]
    public class TestTickRecord
    {
        byte[] data = new byte[] {
	        (byte)0x02, (byte)0x00, (byte)0x03, (byte)0x01, 
                (byte)0x00, (byte)0x00, (byte)0x00, (byte)0x00, (byte)0x00,
                (byte)0x00, (byte)0x00, (byte)0x00, (byte)0x00, 
	        (byte)0x00, (byte)0x00, (byte)0x00,
	        (byte)0x00, (byte)0x00, (byte)0x00, (byte)0x00, 
	        (byte)0x00, (byte)0x00, (byte)0x00, (byte)0x00, (byte)0x23, (byte)0x00, 
	        (byte)0x4D, (byte)0x00, (byte)0x00, (byte)0x00
            };

        public TestTickRecord()
        {

        }
        [Test]
        public void TestLoad()
        {
            TickRecord record = new TickRecord(TestcaseRecordInputStream.Create(0x101e, data));
            ClassicAssert.AreEqual((byte)2, record.MajorTickType);
            ClassicAssert.AreEqual((byte)0, record.MinorTickType);
            ClassicAssert.AreEqual((byte)3, record.LabelPosition);
            ClassicAssert.AreEqual((short)1, record.Background);
            ClassicAssert.AreEqual(0, record.LabelColorRgb);
            ClassicAssert.AreEqual((short)0, record.Zero1);
            ClassicAssert.AreEqual((short)0, record.Zero2);
            ClassicAssert.AreEqual((short)35, record.Options);
            ClassicAssert.AreEqual(true, record.IsAutoTextColor);
            ClassicAssert.AreEqual(true, record.IsAutoTextBackground);
            ClassicAssert.AreEqual((short)0x0, record.Rotation);
            ClassicAssert.AreEqual(true, record.IsAutorotate);
            ClassicAssert.AreEqual((short)77, record.TickColor);
            ClassicAssert.AreEqual((short)0x0, record.Zero3);


            ClassicAssert.AreEqual(34, record.RecordSize);
        }
        [Test]
        public void TestStore()
        {
            TickRecord record = new TickRecord();
            record.MajorTickType=((byte)2);
            record.MinorTickType=((byte)0);
            record.LabelPosition=((byte)3);
            record.Background=((byte)1);
            record.LabelColorRgb=(0);
            record.Zero1=((short)0);
            record.Zero2=((short)0);
            record.Options=((short)35);
            record.IsAutoTextColor=(true);
            record.IsAutoTextBackground=(true);
            record.Rotation=((short)0);
            record.IsAutorotate=(true);
            record.TickColor=((short)77);
            record.Zero3=((short)0);


            byte[] recordBytes = record.Serialize();
            ClassicAssert.AreEqual(recordBytes.Length - 4, data.Length);
            for (int i = 0; i < data.Length; i++)
                ClassicAssert.AreEqual(data[i], recordBytes[i + 4], "At offset " + i);
        }
    }
}
