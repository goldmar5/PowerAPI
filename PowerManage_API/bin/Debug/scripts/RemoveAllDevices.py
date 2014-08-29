print ""
time.sleep (0.5)
print "####################################################################"
time.sleep (0.5)
print "###################### Remove All Devices ##########################"
time.sleep (0.5)
print "####################################################################"
time.sleep (0.5)


for _panel in list_of_panels:
	p = panel.Panel(_panel)
	task = p.GetDevices()
	task_list.append(task)
	task.next()

zones = []
for task in task_list:
	for i in task:
		if i.IsInProgress():
			SendData ("Waiting for PMaxStateGet for %s..." % i.PanelID())
			time.sleep (5)
		
		if i.IsSucceeded() :
			SendData ("PMaxStateGet %s SUCCEEDED." % i.PanelID())
			time.sleep (0.5)
			zones = i.GetResult()
			print zones
			time.sleep (0.5)		
		
		if i.IsFailed():
			SendData ("PMaxStateGet %s FAILED    : %s." % (i.PanelID(), i.GetError()))
			time.sleep (0.5)

for zone in zones :
	if zone["device type"] == 1:
		device_type = "Zone"
	if zone["device type"] == 2:
		device_type = "Keyfob"
	if zone["device type"] == 4:
		device_type = "Keypad"
	if zone["device type"] == 5:
		device_type = "Siren"
	if zone["device type"] == 14:
		device_type = "Pendant"
	if zone["device type"] == 98:
		device_type = "Repeater"
	SendData ("Device type: \t%s \tZone ID: \t%s " % (device_type, str(zone["zone ID"])))
	time.sleep(0.5)
	
task_list = []
for _panel in list_of_panels:
	p = panel.Panel(_panel)
	for zone in zones :
		task = p.RemoveDevice(zone["device type"], zone["zone ID"])
		task_list.append(task)
		task.next()
		
for task in task_list:
	for i in task:
		if i.IsSucceeded():
			SendData ("PMaxZoneRemove %s SUCCEEDED." % i.PanelID())
			time.sleep (0.5)
		
		if i.IsFailed():
			SendData ("PMaxZoneRemove %s FAILED    : %s." % (i.PanelID(), i.GetError()))