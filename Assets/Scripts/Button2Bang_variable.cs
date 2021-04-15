// Button2Bang_variable.cs - Script to send a bang to a PD patch when the player enters
//	and leaves a collision volume. This version includes the addition of
// 2 public variables so that bangs can have specific names, and a float number
// is also sent to Pd. In the example this is used to control pitch.
// -----------------------------------------------------------------------------
// Copyright (c) 2018 Niall Moody, with modifications in 2021 by Yann Seznec
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
// -----------------------------------------------------------------------------
// 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Script to send a bang to a PD patch when the player enters and leaves a
/// collision volume.
public class Button2Bang_variable : MonoBehaviour
{

	/// The PD patch we're going to communicate with.
	public LibPdInstance pdPatch;
	public float pitch;
	public string filename;

	private void Start()
	{
		pdPatch.SendSymbol("filename", filename);
	}

	/// We send a bang when the player steps on the button (enters the collision
	/// volume).
	void OnTriggerEnter(Collider other)
	{
		pdPatch.SendFloat("pitch", pitch);
		pdPatch.SendBang("triggerOn");
		

	}

	/// We send a different bang when the player steps off the button (leaves
	/// the collision volume).
	void OnTriggerExit(Collider other)
	{
		pdPatch.SendBang("triggerOff");
	}
}
