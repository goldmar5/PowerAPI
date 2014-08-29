print ""
time.sleep (0.5)
print "####################################################################"
time.sleep (0.5)
print "############################ Get RSSI ##############################"
time.sleep (0.5)
print "####################################################################"
time.sleep (0.5)


for _panel in list_of_panels:
	p = panel.Panel(_panel)
	task = p.GetLinkQuality()
	task_list.append(task)
	task.next()

for task in task_list:
	for i in task:		
		if i.IsInProgress():
			SendData ("Checking PMaxZoneRssi for %s..." % i.PanelID())
			time.sleep (5)
		
		if i.IsFailed():
			SendData ("PMaxZoneRssi %s FAILED    : %s." % (i.PanelID(), i.GetError()))
				
		if i.IsSucceeded():
			SendData ("PMaxZoneRssi %s SUCCEEDED." % i.PanelID())
			time.sleep (0.5)
			print i.GetResult()
			time.sleep(4)
						
		time.sleep (0.5)