print ""
time.sleep (0.5)
print "####################################################################"
time.sleep (0.5)
print "####################### Get Standard Log ###########################"
time.sleep (0.5)
print "####################################################################"
time.sleep (0.5)


for _panel in list_of_panels:
	p = panel.Panel(_panel)
	task = p.GetLog(LOG_TYPE_STANDARD)
	task_list.append(task)
	task.next()

for task in task_list:
	for i in task:		
		if i.IsInProgress():
			SendData ("Checking PMaxLogStandard for %s..." % i.PanelID())
			time.sleep (5)
		
		if i.IsFailed():
			SendData ("PMaxLogStandard %s FAILED    : %s." % (i.PanelID(), i.GetError()))
				
		if i.IsSucceeded():
			SendData ("PMaxLogStandard %s SUCCEEDED." % i.PanelID())
			time.sleep (0.5)
			print i.GetResult()
			time.sleep(8)
						
		time.sleep (0.5)