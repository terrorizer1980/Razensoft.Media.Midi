﻿using System;
using System.IO;
using NUnit.Framework;
using Shouldly;

namespace Razensoft.Media.Midi.Tests
{
    [TestFixture]
    public class ChunkTests
    {
        [Test]
        [TestCase(new byte[] { 0x00, 0xFF }, TestName = "Header length < 4")]
        [TestCase(new byte[] { 0x00, 0x01, 0x10, 0xAA, 0x1F, 0xFF }, TestName = "Header length > 4")]
        public void Header_LengthNotFour_FailToAssign(byte[] header)
        {
            var chunk = new Chunk();
            Should.Throw<ArgumentOutOfRangeException>(() => chunk.Header = header);
        }

        [Test]
        [TestCase("MT", TestName = "Header length < 4")]
        [TestCase("MThdMT", TestName = "Header length > 4")]
        public void AsciiHeader_LengthNotFour_FailToAssign(string asciiHeader)
        {
            var chunk = new Chunk();
            Should.Throw<ArgumentOutOfRangeException>(() => chunk.AsciiHeader = asciiHeader);
        }
    }

    [TestFixture]
    public class MidiFileTests
    {
        [Test]
        public void Read_NormalFile_SuccessfulRead()
        {
            var sourceStream = new MemoryStream();
            // TODO: add arranging
            using (var midiFile = new MidiFile(sourceStream, MidiFileMode.Read))
            {

            }
        }
    }
}