#!/usr/bin/env ruby

require "json"

original_content = File.read("mod.json")
parsed = JSON.parse(original_content)
puts parsed
#puts "-------"
#puts parsed["Settings"]
#puts parsed
#puts "-------"
# File.open(filename, 'w') { |file| file.write(JSON.pretty_generate(parsed)) }
# changed_content = File.read(filename)
# puts changed_content

puts
puts "hit enter key to end program"
gets
