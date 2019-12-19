Author: David Brungardt
Date: 12/19/2019

The purpose of this program is to automate the modeling of bolted angle bracing connections in Tekla Structures using the Tekla API.
This program is not intended for actual use in production, it is just a project I've been working on to get some more practice developing using C# and the Tekla API.
The program takes four plates and four points as input, this allows the angle bracing to be modeled along the load path for the angles.
From there, you can offset the angles along the load path, change the type of angle (currently 3 options), adjust the quantity of bolts, and determine whether or not you want the angles centered on the load path, or offset a specific distance.

At the moment, I'm still planning on adding some functionality to add a single bolt to the single angle bracing connections, I'm also planning on adding some functionality (which is already built into the form) for a double angle bracing connection with back to back angles and a connection plate in the center.

Despite the plugin not being finished, the entire single angle bracing is being modeled in with the exception of the center bolt.
At the time of this README, I've written about 2,131 lines of code!
With that in mind; I figured it was enough work to upload the current repository to GitHub, it will just give me the chance to work with the GitBash command line some more as the application progresses!
