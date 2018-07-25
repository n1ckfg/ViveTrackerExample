**Use the Vive Tracker without a headset:**
<ol>
	<li>If you haven't already, use the headset and controllers to run Room Setup.</li>
	<li>Disconnect both the headset and link box, turn off the controllers, and connect the tracker dongle.</li>
	<li>Restart SteamVR and pair the tracker to its own dongle.</li>
	<li>Once you're sure the tracker is paired to the dongle, reconnect just the link box (it controls the Lighthouses).
	<li>In your file manager, go to the global SteamVR settings file:<br>
	<i>C:\Program Files (x86)\Steam\steamapps\common\SteamVR\resources\settings\default.vrsettings</i></li>
	<li>
		Back up the global default.vrsettings, then open it in a text editor and set the following:
		<pre>
"requireHmd" : false,
"activateMultipleDrivers" : true,</pre>
	</li>
	<li>Then, in your file manager, go to the null driver settings file:<br>
	<i>C:\Program Files (x86)\Steam\steamapps\common\SteamVR\drivers\null\resources\settings\default.vrsettings</i></li>
	<li>
		Back up the null driver default.vrsettings, then open it in a text editor and set the following:
		<pre>
"enable" : true,</pre>
	</li>
	<li>
		Now restart SteamVR. If everything's correct, the SteamVR panel should say "Ready" when the tracker alone is connected:
		<table>
			<tr>
		   		<th><b>Good ending:</b></th>
		   		<th><b>Bad ending:</b></th>
		 	</tr>
			<tr>
				<td>
					<img src="./docs/images/tracker_good.png">
				</td>
				<td>
					<img src="./docs/images/tracker_bad.png">
				</td>
			</tr>
		</table>
	</li>
	<li>Now that you're set up, switch between headset and tracker mode by plugging in or removing the headset (leaving the link box connected) and restarting SteamVR.</li>
</ol>

**Optional**
<ol>
	<li>
		If you want to disable the headset entirely, also change the following in global settings:
		<pre>
"forcedDriver" : "null",</pre>
	</li>
	<li>Or, to restore normal operation of your headset later, change it back:
		<pre>
"forcedDriver": "",</pre>
	</li>
</ol>

**Troubleshooting:**
<ol>
	<li>
		If you have trouble running Room Setup after performing these steps, try temporarily changing this global setting:
		<pre>
"requireHmd" : false,</pre>	
	</li>
	<li>If SteamVR complains about needing to rerun Room Setup, try restarting it again and see if the warning goes away.
	<li>
		If SteamVR <i>keeps</i> complaining about Room Setup, go to:<br>
		<i>C:\Program Files (x86)\Steam\config\chaperone_info.vrchap</i><br>
		Make any harmless change to the file (like adding a space at the end), then save it.
	</li>
	<li>If you're still having problems, try the current beta of SteamVR. In Steam, right-click SteamVR in your library and enable Beta mode.</li>
</ol>

**More info:**<br>
https://developer.valvesoftware.com/wiki/SteamVR/steamvr.vrsettings<br>
http://pencilsquaregames.com/getting-steamvr-tracking-data-in-unity-without-a-hmd<br>
https://reddit.com/r/Vive/comments/6uo053/how_to_use_steamvr_tracked_devices_without_a_hmd<br>
https://reddit.com/r/Vive/comments/4ly634/room_setup_files_location_steamvr<br>
https://reddit.com/r/Vive/comments/6n374w/bluetooth_question<br>
https://roadtovr.com/how-to-use-the-htc-vive-tracker-without-a-vive-headset<br>
https://steamcommunity.com/app/358720/discussions/0/485624149150957321/#c1290690926862315884<br>
https://steamcommunity.com/app/358720/discussions/0/485624149150957321<br>
https://vive.com/eu/support/vive/category_howto/optin-to-steamvr-beta.html<br> 
