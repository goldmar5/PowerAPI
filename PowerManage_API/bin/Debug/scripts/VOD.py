print ""
time.sleep (0.5)
print "####################################################################"
time.sleep (0.5)
print "############################ Get VOD ###############################"
time.sleep (0.5)
print "####################################################################"
time.sleep (0.5)


for _panel in list_of_panels:
	p = panel.Panel(_panel)
	task = p.FilmOnDemand(1, 10)
	task_list.append(task)
	task.next()

for task in task_list:
	for i in task:		
		if i.IsInProgress():
			SendData ("Checking PMaxFilmOnDemand for %s..." % i.PanelID())
			time.sleep (5)
			
		if i.IsPartiallyReady():
			temp_data = i.GetResult()
			#SendData ("total_files: %d\n" % temp_data["total_files"])
			#SendData ("arrived_files: %d\n" % temp_data["arrived_files"])
			time.sleep(1)
		
		if i.IsFailed():
			SendData ("PMaxFilmOnDemand %s FAILED    : %s." % (i.PanelID(), i.GetError()))
				
		if i.IsSucceeded():
			SendData ("PMaxFilmOnDemand %s SUCCEEDED." % i.PanelID())
			time.sleep (0.5)
			for f in i.GetResult()["files"]:
				SendData ("num: %d \nsize: %d \ntype: %s \ndata: %s" % (f["frame_number"], len(f["buffer"]), f["type"], f["buffer"]))
				time.sleep(1)
						
		time.sleep (0.5)