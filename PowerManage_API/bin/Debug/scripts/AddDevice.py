print ""
time.sleep (0.5)
print "####################################################################"
time.sleep (0.5)
print "########################### Add Device #############################"
time.sleep (0.5)
print "####################################################################"
time.sleep (0.5)

SendData("Which devices you need? '300 1245 1,'")

devices = ReadData()
list_of_devices = [tuple(i.split(' ')) for i in devices.split(', ')]

for _panel in list_of_panels:
	p = panel.Panel(_panel)
	for device in list_of_devices:
		task = p.AddDevice(str(device[0]), str(device[1]), int(device[2]))
		task_list.append(task)
		task.next()
		SendData("Device '%s-%s' will be added to zone %s" % (device[0], device[1], device[2]))
		time.sleep(0.5)


for task in task_list:
	for i in task:		
		#if i.IsInProgress():
		#	SendData ("Checking PMaxZoneAdd for %s..." % i.PanelID())
		#	time.sleep (5)
		
		if i.IsFailed():
			SendData ("PMaxZoneAdd %s FAILED    : %s." % (i.PanelID(), i.GetError()))
				
		if i.IsSucceeded():
			SendData ("PMaxZoneAdd %s SUCCEEDED." % i.PanelID())
			time.sleep (0.5)
						
		time.sleep (0.5)