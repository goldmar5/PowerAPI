print ""
time.sleep (0.5)
print "####################################################################"
time.sleep (0.5)
print "######################### Get Configuration ########################"
time.sleep (0.5)
print "####################################################################"
time.sleep (0.5)


for _panel in list_of_panels:
	p = panel.Panel(_panel)
	task = p.GetConfiguration()
	task_list.append(task)
	task.next()

for task in task_list:
	for i in task:		
		if i.IsInProgress():
			SendData ("Checking process PMaxConfigDownload for %s..." % i.PanelID())
			time.sleep (5)
		
		if i.IsFailed():
			SendData ("PMaxConfigDownload %s FAILED    : %s." % (i.PanelID(), i.GetError()))
				
		if i.IsSucceeded():
			SendData ("PMaxConfigDownload %s SUCCEEDED." % i.PanelID())
			time.sleep (0.5)
			SendData(i.GetResult())
			time.sleep(15)
			
		time.sleep (0.5)