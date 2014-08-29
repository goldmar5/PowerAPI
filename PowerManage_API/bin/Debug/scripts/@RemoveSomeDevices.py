for _panel in list_of_panels:
	p = panel.Panel(_panel)
	task = p.GetDevices()
	task_list.append(task)
	task.next()

zones = []
for task in task_list:
	for i in task:
		if i.IsSucceeded() :
			zones = i.GetResult()
			print zones
			time.sleep (0.5)
			
		if i.IsInProgress():
			SendData ("Waiting for PMaxStateGet for %s..." % i.PanelID())
			time.sleep (5)
		
		if i.IsFailed():
			SendData ("PMaxStateGet FAILED(%s): " % i.PanelID() + i.GetError())
			time.sleep (0.5)

for zone in zones :
	SendData ("Device type: " + str(zone["device type"]) + "  ")
	SendData ("Zone ID: " + str(zone["zone ID"]) + "  ")
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
			SendData ("PMaxZoneRemove (%s) succeeded" % i.PanelID())
			time.sleep (0.5)
		
		if i.IsFailed():
			SendData ("PMaxZoneRemove FAILED(%s): " % i.PanelID() + i.GetError())