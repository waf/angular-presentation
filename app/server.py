import cherrypy
import json
import os.path
from cherrypy import tools

class StaticFiles(object):
    @cherrypy.expose
    def index(self):
        return open("index.html").read()

class Distrowatch(object):

    @cherrypy.expose
    @tools.json_out()
    def distros(self, distro_id = None):
        filename = "distros.json" if not distro_id else distro_id + ".json" 
        return json.loads(open("api/" + filename).read())

current_dir = os.path.dirname(os.path.abspath(__file__))
cherrypy.tree.mount(StaticFiles(), "/", config = {
    '/' : {
        "tools.staticdir.on" : True,
        "tools.staticdir.dir" : current_dir
    }
})
cherrypy.tree.mount(Distrowatch(), '/api') 
cherrypy.engine.start() 
cherrypy.engine.block() 
