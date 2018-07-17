#To use the Vive Tracker without a headset:#
<ol>
	<li>Go to:<br>
	C:\Program Files (x86)\Steam\steamapps\common\SteamVR\resources\settings</li>
	<li>Back up default.vrsettings.</li>
	<li>
		Open default.vrsettings in a text editor and set the following:
		<pre>
"requireHmd" : false
"forcedDriver" : "null"
"activateMultipleDrivers" : true</pre>
	</li>
	<li>
		Then add the following to the end (don't forget the comma on the preceding line!):
		<pre>
,
{
	"driver_null" : {
		"enable" : true,
		"serialNumber" : "Null Serial Number", 
		"modelNumber" : "Null Model Number",
		"windowX" : 0,
		"windowY" : 0,
		"windowWidth" : 2160,
		"windowHeight" : 1200,
		"renderWidth" : 1512,
		"renderHeight" : 1680,
		"secondsFromVsyncToPhotons" : 0.01111111,
		"displayFrequency" : 90.0
	}
}</pre>
	</li>
	<li>Save and close default.vrsettings and restart SteamVR.</li>
	<li>Connect the headset and controllers to test that they still work.</li>
	<li>Do roomscale setup now, if you haven't already.</li>
	<li>Disconnect the headset and link box, turn off the controllers, and connect the tracker dongle.</li>
	<li>Restart SteamVR and pair the tracker to the dongle.</li>
	<li>If everything's correct, the SteamVR panel should no longer say "Not Ready" when the tracker alone is connected.</li>
	<li>You should now be able to start SteamVR and use the tracker.</li>
</ol>

<img src="./docs/images/tracker_succeed.png"><br>

More info:<br>
https://www.roadtovr.com/how-to-use-the-htc-vive-tracker-without-a-vive-headset/<br>
http://www.pencilsquaregames.com/getting-steamvr-tracking-data-in-unity-without-a-hmd/<br>

