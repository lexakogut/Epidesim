﻿#version 330 core

in vec4 texColor;
in vec2 texCoord;

uniform sampler2D texture0;

void main()
{
	gl_FragColor = texture(texture0, texCoord) * texColor;
}