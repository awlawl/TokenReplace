TokenReplace is a very simple windows command line tool that uses settings that are in its config file to replace tokens in any text file.

So for example, using this TokenReplace.exe.config:

<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <appSettings>
	<add key="TOKEN1" value="Robot"/>
	<add key="TOKEN2" value="Break Dancing"/>
	<add key="XML_TOKEN" value="This is &quot;serious&quot; statement &lt;--here--&gt;"/>
  </appSettings>
</configuration>

And this token file named "tokenized.txt":
This is a test of @TOKEN1@ and @TOKEN1@ and @TOKEN2@. This token has characters that need xml escaping @XML_TOKEN@

With this command line:

TokenReplace tokenized.txt output.txt

Will create a file named "output.txt" that contains:

This is a test of Robot and Robot and Break Dancing. This token has characters that need xml escaping This is "serious" statement <--here-->

But why? Aren't there a million ways to do this in some kind of shell script?
I use Octopus for deployments. Right now it manages the settings only through appSettings and connectionString replacements in .config files. So this is a way to bridge the gap between what it can do now and a more generic token replacement.

