print ""
time.sleep (0.5)
print "####################################################################"
time.sleep (0.5)
print "############################ Walk TEST #############################"
time.sleep (0.5)
print "####################################################################"
time.sleep (0.5)


for _panel in list_of_panels:
	p = panel.Panel(_panel)
	task = p.WalkTest(10, 600)
	task_list.append(task)
	task.next()

for task in task_list:
	for i in task:		
		if i.IsInProgress():
			SendData ("Checking process PMaxZoneWalkTest for %s..." % i.PanelID())
			time.sleep (20)
		
		if i.IsFailed():
			SendData ("PMaxZoneWalkTest %s FAILED    : %s." % (i.PanelID(), i.GetError()))
				
		if i.IsSucceeded():
			SendData ("PMaxZoneWalkTest %s SUCCEEDED." % i.PanelID())
			time.sleep (0.5)
			#SendData(i.GetResult())
			time.sleep(15)
			
		time.sleep (0.5)